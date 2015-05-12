using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Domain
{
    public class JiraRequest
    {
        private const string ClientNameField = "customfield_10200";
        private readonly WebClient _client;

        public JiraRequest(WebClient client)
        {
            _client = client;
        }

        public int JirasWithStatusForProjectCode(string status, string projectCode)
        {
            var url = string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=status='{0}' AND project={1} AND 'T3 - Type' != 'Enhancement'", status, projectCode);
            var response = _client.DownloadString(url);
            var json = JObject.Parse(response);
            Console.WriteLine("Time polled: {0}", DateTime.Now);
            Console.WriteLine("Json: {0}", json);
            Console.WriteLine();
            return (int)json["total"];
        }

        private static QueryResult GetJirasFromResult(string response)
        {
            var json = JObject.Parse(response);
            var issues = json["issues"].ToObject<JArray>();
            var total = json["total"].ToObject<int>();

            var jirasFromResult = issues.Select(issue => new {issue, fields = issue["fields"]}).Select(@t => new Jira
            {
                Name = @t.issue["key"].ToString(),
                Summary = @t.fields["summary"].ToString(),
                DateCreated = @t.fields["created"].ToObject<DateTime>(),
                Client = @t.fields[ClientNameField] != null ? @t.fields[ClientNameField].ToString() : "No Client Set",
                Reporter = @t.fields["reporter"]["displayName"].ToString(),
                Assignee = @t.fields["assignee"].ToString() != "" ? @t.fields["assignee"]["displayName"].ToString() : ""
            }).ToList();
            
            return new QueryResult
            {
                Total = total,
                Jiras = jirasFromResult
            };
        }

        public int MLCT3AwaitingTriage()
        {
            return JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLC");
        }

        public int LaserformT3AwaitingTriage()
        {
            return JirasWithStatusForProjectCode("Awaiting Triage", "LCSLF");
        }

        public QueryResult SearchMLCJirasBatched(SearchItem searchItem, int pageNumber)
        {
            var query = new QueryBuilder().BuildBatched(searchItem, pageNumber);
            return GetJirasFromResult(_client.DownloadString(query));
        }

        public List<string> IssueTypes()
        {
            var issueTypes = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/issuetype");
            return JArray.Parse(issueTypes)
                .Select(issue => issue["name"])
                .Select(issueTypeName => (string) issueTypeName).ToList();
        }

        public Dictionary<int, string> Components()
        {
            var issueTypes = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/project/LCSMLC");
            var array = JObject.Parse(issueTypes)["components"].ToList();

            var components = new Dictionary<int, string> {{0, "Any"}};
            foreach (var component in array)
            {
                components.Add(component["id"].ToObject<int>(),component["name"].ToString());
            }
            return components;
        }

        public Dictionary<int, string> Versions()
        {
            var issueTypes = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/project/LCSMLC");
            var array = JObject.Parse(issueTypes)["versions"].ToList();

            var versions = new Dictionary<int, string> { { 0, "Any" } };

            foreach (var component in array)
            {
                versions.Add(component["id"].ToObject<int>(),component["name"].ToString());
            }
            return versions;
        }
    }

    public class QueryResult
    {
        public int Total { get; set; }
        public List<Jira> Jiras { get; set; }
    }

    public class Jira
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime DateCreated { get; set; }
        public string Client { get; set; }
        public string Reporter { get; set; }
        public string Assignee { get; set; }
    }
}