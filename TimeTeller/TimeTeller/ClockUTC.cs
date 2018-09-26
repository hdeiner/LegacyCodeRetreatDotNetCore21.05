using System;

namespace TimeTeller
{
    class ClockUTC : Clock
    {
        private DateTimeOffset localDateTime;

        public ClockUTC()
        {
            timeZone = TimeZones.UTC;
            localDateTime = new DateTimeOffset(DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc));
        }

        public override int GetHour() { return localDateTime.Hour; }
        public override int GetMinute() { return localDateTime.Minute; }
        public override int GetSecond() { return localDateTime.Second; }

    }
}
