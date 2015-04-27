using System;
using System.Media;
using System.Threading;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var conf = new ApplicationConfig();
            var jiraReq = new JiraRequest(new User().AuthenticationToken());
            var soundPlayer = new SoundPlayer(Resources.alarm);

            while (true)
            {
                var result = jiraReq.T3TotalWithStatus(conf.Status);
                if (result >= 1)
                {
                    soundPlayer.Play();
                }
                Thread.Sleep(TimeSpan.FromSeconds(conf.WaitTime));
            }
        }
    }
}
