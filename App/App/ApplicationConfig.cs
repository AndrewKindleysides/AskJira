using System;
using System.Configuration;

namespace App
{
    public class ApplicationConfig
    {
        public string Status { get; set; }
        public double WaitTime { get; set; }
        public ApplicationConfig()
        {
            Status = ConfigurationManager.AppSettings["Status"];
            WaitTime = Convert.ToDouble(ConfigurationManager.AppSettings["WaitTimeInSeconds"]);
        }
    }
}