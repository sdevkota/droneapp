using System.Collections.Generic;

namespace DroneScheduler
{
    public interface IUtilityService
    {
        string GetSecondsToHMS(double seconds);
        double GetTimeInSeconds(string hr, string min, string sec);
        double GetTimeInSecondsFromRawString(string time);
        int ParseStringToInt(string stringValue);
    }
}