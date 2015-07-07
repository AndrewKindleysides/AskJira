﻿using System;
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
                var projectsWithT3 = request().ProjectsWithT3;
                if (projectsWithT3.Count >= 1)
                    foreach (var project in projectsWithT3)
                    {
                        _soundPlayers[project.Key].Play();
                    }
                
                Thread.Sleep(TimeSpan.FromSeconds(_waitTime));
            }
        }
    }
}