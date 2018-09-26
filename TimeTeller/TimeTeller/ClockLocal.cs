using System;

namespace TimeTeller
{
    class ClockLocal : Clock
    {
        private DateTimeOffset localDateTime;

        public ClockLocal()
        {
            timeZone = TimeZones.LOCAL;
            localDateTime = new DateTimeOffset(DateTime.Now);
        }

        public override int GetHour() { return localDateTime.Hour; }
        public override int GetMinute() { return localDateTime.Minute; }
        public override int GetSecond() { return localDateTime.Second; }

    }
}
