using System;
using Xunit;

namespace TimeTeller
{
    public class TimeFormatterTests
    {

        [Fact]
        public void localTimeCurrent()
        {
            Assert.Equal(getFormattedTimeLocal(DateTime.Now), new TimeFormatterNumeric(new ClockLocal()).FormatTime());
        }

        [Fact]
        public void zuluTimeCurrent()
        {
            Assert.Equal(getFormattedTimeUTC(DateTime.UtcNow), new TimeFormatterNumeric(new ClockUTC()).FormatTime());
        }

        [Fact]
        public void localTimeNumeric102445()
        {
            Assert.Equal("10:24:45", new TimeFormatterNumeric(new ClockForTesting(10, 24, 45, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void zuluTimeNumeric102445()
        {
            Assert.Equal("10:24:45Z", new TimeFormatterNumeric(new ClockForTesting(10, 24, 45, TimeZones.UTC)).FormatTime());
        }

        [Fact]
        public void zuluTimeInWords000005()
        {
            Assert.Equal("about twelve at night Zulu", new TimeFormatterApproximateWording(new ClockForTesting(0, 0, 5, TimeZones.UTC)).FormatTime());
        }

        [Fact]
        public void localTimeInWords000005()
        {
            Assert.Equal("about twelve at night", new TimeFormatterApproximateWording(new ClockForTesting(0, 0, 5, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords090239()
        {
            Assert.Equal("a little after nine in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 2, 39, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords090949()
        {
            Assert.Equal("about ten after nine in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 9, 49, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords091702()
        {
            Assert.Equal("about a quarter after nine in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 17, 2, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords091902()
        {
            Assert.Equal("about twenty after nine in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 19, 2, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords092312()
        {
            Assert.Equal("almost half past nine in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 23, 12, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords093112()
        {
            Assert.Equal("about half past nine in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 31, 12, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords093623()
        {
            Assert.Equal("almost twenty before ten in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 36, 23, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords093823()
        {
            Assert.Equal("about twenty before ten in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 38, 23, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords094145()
        {
            Assert.Equal("about a quarter of ten in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 43, 45, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords094945()
        {
            Assert.Equal("about ten of ten in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 49, 45, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords095801()
        {
            Assert.Equal("almost ten in the morning", new TimeFormatterApproximateWording(new ClockForTesting(9, 53, 1, TimeZones.LOCAL)).FormatTime());
        }

        [Fact]
        public void localTimeInWords120105()
        {
            Assert.Equal("about twelve in the afternoon", new TimeFormatterApproximateWording(new ClockForTesting(12, 1, 5, TimeZones.LOCAL)).FormatTime());
        }

        private String getFormattedTimeLocal(DateTime clock)
        {
            int localHour = clock.Hour;
            int localMinute = clock.Minute;
            int localSecond = clock.Second;
            return localHour.ToString("00") + ":" + localMinute.ToString("00") + ":" + localSecond.ToString("00");
        }

        private String getFormattedTimeUTC(DateTime clock)
        {
            int localHour = clock.Hour;
            int localMinute = clock.Minute;
            int localSecond = clock.Second;
            return localHour.ToString("00") + ":" + localMinute.ToString("00") + ":" + localSecond.ToString("00") + "Z";
        }
    }
}
