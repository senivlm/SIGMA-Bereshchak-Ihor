using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz
{
    enum DayOfWeek
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    class Visitor
    {
       
            private string ip;

            public string Ip
            {
                get
                {
                    return ip;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException();

                if (value.Split('.').Length != 4)
                        throw new ArgumentException("IP it's not correct!");

                    int tempNumber;
                    for (int i = 0; i < 4; i++)
                    {
                        if (!int.TryParse(value.Split('.')[i], out tempNumber))
                            throw new ArgumentException("IP it's not correct!");

                        if (tempNumber > 255 || tempNumber < 0)
                            throw new ArgumentException("IP it's not correct!");
                    }

                    ip = value;
                }
            }

            public DateTime Time { get; set; }

            public DayOfWeek Day { get; set; }

            public Visitor(string ip, DateTime time, DayOfWeek dayOfWeek)
            {
                Ip = ip;

                Time = time;

                Day = dayOfWeek;
            }

            public override string ToString()
            {
                return $"Ip: {Ip}\tTime of visit: {Time:HH:mm:ss}\t Day of visit: {Day}\n";
            }
        }
}
