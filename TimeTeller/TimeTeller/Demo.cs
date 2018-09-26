using System;
using Messenger;

namespace TimeTeller
{
    class Demo
    {
        static void Main(string[] args)
        {
            Email eMail = new Email("configEmail.properties");

            Console.WriteLine(new TimeFormatterNumeric(new ClockLocal()).FormatTime());
            Console.WriteLine(new TimeFormatterNumeric(new ClockUTC()).FormatTime());
            Console.WriteLine(new TimeFormatterApproximateWording(new ClockLocal()).FormatTime());
            Console.WriteLine(new TimeFormatterApproximateWording(new ClockUTC()).FormatTime());

            eMail.Send(new TimeFormatterNumeric(new ClockLocal()).FormatTime());
            eMail.Send(new TimeFormatterNumeric(new ClockUTC()).FormatTime());
            eMail.Send(new TimeFormatterApproximateWording(new ClockLocal()).FormatTime());
            eMail.Send(new TimeFormatterApproximateWording(new ClockUTC()).FormatTime());

            Console.Read();
        }
    }
}
