namespace TimeTeller
{
    public class ClockForTesting : Clock {
        private int hour;
        private int minute;
        private int second;

        public ClockForTesting(int hour, int minute, int second, TimeZones timeZone)
        {
            this.timeZone = timeZone;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public override int GetHour() { return hour; }

        public override int GetMinute() {  return minute; }

        public override int GetSecond() { return second;  }

    }
}
