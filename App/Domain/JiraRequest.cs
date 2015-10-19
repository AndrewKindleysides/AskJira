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
        private readonly string _jiraApiUrl;

        public JiraRequest(WebClient client, string jiraApiUrl)
        {
            _client = client;
            _jiraApiUrl = jiraApiUrl;
        }

        private int JirasWithStatusForProjectCode(string status, string projectCode)
        {
            var url = string.Format("{0}/search?jql=status='{1}' AND project={2} AND 'T3 - Type' != 'Enhancement'", _jiraApiUrl, status, projectCode);
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

        public PingResult AllT3AwaitingTriage()
        {
            var mlcJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLC");
            var mlawJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLAW");
            var lfmJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSLF");
            var iqlJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSIQL");

            var result = new PingResult();
            
            if (mlcJiraCount > 0)
                result.ProjectsWithT3.Add("MLC",mlcJiraCount);    
            
            if (mlawJiraCount > 0)
                result.ProjectsWithT3.Add("MLAW",mlawJiraCount);

            if(lfmJiraCount > 0)
                result.ProjectsWithT3.Add("LFM",lfmJiraCount);

            if (iqlJiraCount > 0)
                result.ProjectsWithT3.Add("IQL", iqlJiraCount);

            return result;
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