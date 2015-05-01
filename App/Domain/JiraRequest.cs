using System;
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
            var issues = JObject.Parse(response)["issues"].ToObject<JArray>();

            return (from issue in issues
                    let fields = issue["fields"]
                    select new Jira()
                    {
                        Name = issue["key"].ToString(),
                        Summary = fields["summary"].ToString(),
                        DateCreated = fields["created"].ToObject<DateTime>(),
                        Client = fields[Customfield].ToString()
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
    }

    public class Jira
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime DateCreated { get; set; }
        public string Client { get; set; }
    }
}