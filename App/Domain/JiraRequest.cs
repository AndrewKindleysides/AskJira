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
            Console.WriteLine("Jiras for: {0}", projectCode);
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

        public int AllT3AwaitingTriage()
        {
            var mlc = JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLC");
            var mlaw = JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLAW");
            var lf = JirasWithStatusForProjectCode("Awaiting Triage", "LCSLF");
            if (mlc > 0 || mlaw > 0 || lf > 0)
                return 1;
            return 0;
        }

        public int MLCT3AwaitingTriage()
        {
            return JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLC");
        }

        public int MLAWT3AwaitingTriage()
        {
            return JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLAW");
        }

        public int LaserformT3AwaitingTriage()
        {
            return JirasWithStatusForProjectCode("Awaiting Triage", "LCSLF");
        }

        public QueryResult SearchMLCJirasBatched(SearchItem searchItem, int pageNumber, int maxResults)
        {
            var query = new QueryBuilder().BuildBatched(searchItem, pageNumber, maxResults);
            return GetJirasFromResult(_client.DownloadString(query));
        }

        public List<string> IssueTypes()
        {
            try
            {
                var issueTypes = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/issuetype");
                return JArray.Parse(issueTypes)
                    .Select(issue => issue["name"])
                    .Select(issueTypeName => (string) issueTypeName).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public Dictionary<int, string> Components()
        {
            try
            {
                var issueTypes = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/project/LCSMLC");
                var components = new Dictionary<int, string> {{0, "Any"}};

                foreach (var component in JObject.Parse(issueTypes)["components"].ToList())
                {
                    components.Add(component["id"].ToObject<int>(), component["name"].ToString());
                }
                return components;
            }
            catch (Exception)
            {
                return new Dictionary<int, string>();
            }
        }

        public Dictionary<int, string> Versions()
        {
            try
            {
                var issueTypes = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/project/LCSMLC");
                var array = JObject.Parse(issueTypes)["versions"].ToList();

                var versions = new Dictionary<int, string> {{0, "Any"}};

                foreach (var component in array)
                {
                    versions.Add(component["id"].ToObject<int>(), component["name"].ToString());
                }
                return versions;
            }
            catch (Exception)
            {
                return new Dictionary<int, string>();
            }
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