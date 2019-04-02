using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroneScheduler
{
    public class UtilityService : IUtilityService
    {
        /// <summary>
        /// Parse String to integer
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public int ParseStringToInt(string stringValue)
        {
            int returnValue = 0;
            if (!Int32.TryParse(stringValue, out returnValue))
            {
                returnValue = -1;
            }
            return returnValue;
        }
        /// <summary>
        /// Convert Second value into HH:MM:SS
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public string GetSecondsToHMS(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"hh\:mm\:ss");
        }
        /// <summary>
        /// Convert Hour, Min, Sec to Seconds
        /// </summary>
        /// <param name="hr"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public double GetTimeInSeconds(string hr, string min, string sec)
        {
            return
                ParseStringToInt(hr) * 3600 +
                ParseStringToInt(min) * 60 +
                ParseStringToInt(sec);
        }
        /// <summary>
        /// Convert raw time( HH: MM:SS) into seconds
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public double GetTimeInSecondsFromRawString(string time)
        {
            var splitted = time.Split(':');
            return GetTimeInSeconds(splitted[0], splitted[1], splitted[2]);
        }

    }
}
