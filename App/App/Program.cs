using Domain;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jiraRequest = new JiraRequest(new UserLogin(new User()).GetAuthenticationToken());
            new T3Alarm().Start(jiraRequest.MLCT3AwaitingTriage);
        }
    }
}