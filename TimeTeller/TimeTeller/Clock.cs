namespace TimeTeller
{
    public class Clock
    {
        public TimeZones timeZone;

        public Clock() { }
        public virtual int GetHour() { return 0; }
        public virtual int GetMinute() { return 0; }
        public virtual int GetSecond() { return 0; }
        public TimeZones GetTimeZone() { return timeZone; }
    }
}
