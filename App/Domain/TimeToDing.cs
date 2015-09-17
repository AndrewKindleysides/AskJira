using System;

namespace Domain
{
    public class TimeToDing
    {
        public bool CheckTime(DateTime now)
        {
            if (InBusinessHours(now) && NotAWeekend(now))
                return true;
            return false;
        }

        private bool NotAWeekend(DateTime now)
        {
            return now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday;
        }

        private static bool InBusinessHours(DateTime now)
        {
            return now.Hour < 17 && now.Hour > 7;
        }
    }
}