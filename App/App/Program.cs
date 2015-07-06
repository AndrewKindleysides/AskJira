using System.Net;
using Domain;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var auth = new UserLogin(new User()).GetAuthenticationToken();
            var webClient = new WebClient
            {
                Headers = new WebHeaderCollection { "Authorization: Basic " + auth }
            };
            var jiraRequest = new JiraRequest(webClient);
            new T3Alarm().Start(jiraRequest.AllT3AwaitingTriage);
        }
    }
}