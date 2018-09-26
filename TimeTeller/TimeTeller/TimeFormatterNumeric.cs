using System;

namespace TimeTeller
{
    class TimeFormatterNumeric : TimeFormatter
    {
        public TimeFormatterNumeric(Clock clock) : base(clock) {}

        public String FormatTime()
        {
            String formattedTime = clock.GetHour().ToString("00") + ":" +  
                                   clock.GetMinute().ToString("00") + ":" + 
                                   clock.GetSecond().ToString("00");
            if (clock.GetTimeZone() == TimeZones.UTC)
            {
                formattedTime += "Z";
            }
            return formattedTime;
        }
    }
}
