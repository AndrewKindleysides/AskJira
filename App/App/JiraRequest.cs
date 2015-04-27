using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace App
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

        public int T3TotalWithStatus(string status)
        {
            var response = _client.DownloadString(
                string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=status='{0}' AND project=LCSMLC", status));
            var json = JObject.Parse(response);
            Console.WriteLine(json);
            return (int)json["total"];
        }
    }
}