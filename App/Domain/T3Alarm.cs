﻿using System;
using System.Media;
using System.Threading;

namespace Domain
{
    public class T3Alarm
    {
        private readonly SoundPlayer _soundPlayer;
        private readonly double _waitTime;

        public T3Alarm()
        {
            _waitTime = new ApplicationConfig().WaitTime;
            _soundPlayer = new SoundPlayer(Resource.alarm);
        }

        public void Start(Func<int> request)
        {
            while (true)
            {
                if (request() >= 1)
                    _soundPlayer.Play();
                Thread.Sleep(TimeSpan.FromSeconds(_waitTime));
            }
        }
    }
}