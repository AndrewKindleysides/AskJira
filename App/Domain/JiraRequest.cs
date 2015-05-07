using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace Domain
{
    public class JiraRequest
    {
        private const string Customfield = "customfield_10200";
        private readonly WebClient _client;

        public JiraRequest(string auth)
        {
            _client = new WebClient
            {
                Headers = new WebHeaderCollection { "Authorization: Basic " + auth }
            };
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

        public List<Jira> MLCJirasBatched()
        {
            var response = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC");
            var totalNumberOfJiras = GetTotalNumberOfJiras(response);

            var listOfJiras = new List<Jira>();
            for (var i = 0; i <= totalNumberOfJiras; i = i + 100)
            {
                var jiraBatch = GetBatchOfJiras(i);
                listOfJiras.AddRange(from jira in jiraBatch
                                     let fields = jira["fields"]
                                     select new Jira
                                     {
                                         Name = jira["key"].ToString(),
                                         Summary = fields["summary"].ToString(),
                                         DateCreated = fields["created"].ToObject<DateTime>(),
                                         Client = fields[Customfield].ToString()
                                     });
            }

            return listOfJiras;
        }

        public List<Jira> MLCJiras()
        {
            var response = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC");
            return GetJirasFromResult(response);
        }

        private static List<Jira> GetJirasFromResult(string response)
        {
            var issues = JObject.Parse(response)["issues"].ToObject<JArray>();

            return issues.Select(issue => new {issue, fields = issue["fields"]}).Select(@t => new Jira
            {
                Name = @t.issue["key"].ToString(),
                Summary = @t.fields["summary"].ToString(),
                DateCreated = @t.fields["created"].ToObject<DateTime>(),
                Client = @t.fields[Customfield] != null ? @t.fields[Customfield].ToString() : "No Client Set",
                Reporter = @t.fields["reporter"]["displayName"].ToString(),
                Assignee = @t.fields["assignee"].ToString() != "" ? @t.fields["assignee"]["displayName"].ToString() : ""
            }).ToList();
        }

        private IEnumerable<JToken> GetBatchOfJiras(int startAt)
        {
            var response = _client.DownloadString(string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC&maxResults=100&startAt={0}", startAt));
            return JObject.Parse(response)["issues"].ToObject<JArray>();
        }

        private int GetTotalNumberOfJiras(string response)
        {
            return JObject.Parse(response)["total"].ToObject<int>();
        }

        public int MLCT3AwaitingTriage()
        {
            return JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLC");
        }

        public int LaserformT3AwaitingTriage()
        {
            return JirasWithStatusForProjectCode("Awaiting Triage", "LCSLF");
        }

        public List<Jira> SearchMLCJiras(string searchItem, DateTime dateFrom, DateTime dateTo, string issueTypeName, string clientName, string componentId, string fixVersionId)
        {
            var searchText = "";
            var issueType = "";
            var client = "";
            var component = "";
            var version = "";

            if (!string.IsNullOrEmpty(fixVersionId))
                version = string.Format("AND FixVersion = '{0}'", fixVersionId);

            if (!string.IsNullOrEmpty(componentId))
                component = string.Format("AND component = '{0}'", componentId);

            if(!string.IsNullOrEmpty(searchItem))
                searchText = string.Format("AND (summary ~ '{0}' OR description ~ '{0}' OR comment ~ '{0}')", searchItem);

            if (!string.IsNullOrEmpty(clientName))
                client = string.Format("AND cf[10200]~'{0}'", clientName);


            if(issueTypeName != "Any")
                issueType = string.Format("AND issuetype = '{0}'",issueTypeName);

            var dateRange = string.Format("AND (created >= '{0}' AND created <= '{1}')", dateFrom.Date.ToString("yyyy-MM-dd h:mm").Replace('/', '-'), dateTo.Date.ToString("yyyy-MM-dd h:mm").Replace('/', '-'));

            var address = string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC {0} {1} {2} {3} {4} {5}", searchText, dateRange, issueType, client, component, version);
            var response = _client.DownloadString(address);
            return GetJirasFromResult(response);
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

            var components = new Dictionary<int, string>();

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

            var versions = new Dictionary<int, string>();

            foreach (var component in array)
            {
                versions.Add(component["id"].ToObject<int>(),component["name"].ToString());
            }
            return versions;
        }
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