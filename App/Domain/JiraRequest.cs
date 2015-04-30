using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Domain
{
    public class JiraRequest
    {
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

        public dynamic MLCJiras()
        {
            var response = _client.DownloadString("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC");
            return JObject.Parse(response);
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
}