namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jiraRequest = new JiraRequest(new User().AuthenticationToken());
            new AskJira().Start(jiraRequest.MLCT3AwaitingTriage);
        }
    }
}