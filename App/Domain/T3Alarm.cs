using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace Domain
{
    public class T3Alarm
    {
        private readonly SoundPlayer _soundPlayer;
        private readonly double _waitTime;
        private Dictionary<string, SoundPlayer> _soundPlayers;

        public T3Alarm()
        {
            _waitTime = new ApplicationConfig().WaitTime;
            _soundPlayers = new Dictionary<string, SoundPlayer>
            {
                {"MLC", new SoundPlayer(Resource.MLC)},
                {"MLAW", new SoundPlayer(Resource.MLAW)},
                {"LFM", new SoundPlayer(Resource.LFM)}
            };
        }

        public void Start(Func<PingResult> request)
        {
            while (true)
            {
                var projectsWithT3S = request().ProjectsWithT3s;
                if (projectsWithT3S.Count >= 1)
                    foreach (var pair in projectsWithT3S)
                    {
                        _soundPlayers[pair.Key].Play();
                    }
                
                Thread.Sleep(TimeSpan.FromSeconds(_waitTime));
            }
        }
    }

    public class PingResult
    {
        public Dictionary<string, int> ProjectsWithT3s { get; set; } 
        public PingResult()
        {
            ProjectsWithT3s = new Dictionary<string, int>();
        }
    }
}