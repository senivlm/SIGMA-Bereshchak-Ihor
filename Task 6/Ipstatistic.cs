using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dz
{
    class Ipstatistic
    {
        public List<ipAddress> arrIp { get; set; }

        public Ipstatistic()
        {
            arrIp = new List<ipAddress>();
        }

        public void readfromfile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string[] text = reader.ReadToEnd().Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in text)
            {
                Addip(item);
            }

            reader.Close();
        }

        public static bool checkip(string ip)
        {
            if (ip == null)
                return false;

            if (ip.Split('.').Length != 4)
                return false;

            int tempNumber;
            for (int i = 0; i < 4; i++)
            {
                if (!int.TryParse(ip.Split('.')[i], out tempNumber))
                    return false;

            }

            return true;

        }

        public void Addip(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException();

            string[] data = line.Trim('\r').Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
 

            if (!checkip(data[0]))
                throw new ArgumentException();

            string ip = data[0];

            bool result = DateTime.TryParseExact(data[1], "HH:mm:ss", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out DateTime time);

           

            DayOfWeek day;

            switch (data[2])
            {
                case "Monday":day = DayOfWeek.Monday;
                    break;
                    
                case "Tuesday":day = DayOfWeek.Tuesday;
                    break;
                    
                case "Wednesday":day = DayOfWeek.Wednesday;
                    break;
                    
                case "Thursday":day = DayOfWeek.Thursday;
                    break;
                    
                case "Friday":day = DayOfWeek.Friday;
                    break;
                    
                case "Saturday":day = DayOfWeek.Saturday;
                    break;
                    
                case "Sunday":day = DayOfWeek.Sunday;
                    break;
                    
                default: throw new ArgumentException("Error");
            }

            arrIp.Add(new ipAddress(ip, time, day));
        }

        public int getcountvisits(string ip)
        {
            if (!checkip(ip))
                throw new ArgumentException("Eror");

            return arrIp.Where(i => i.Ip == ip).ToList().Count;
        }

        public DayOfWeek getpopularday(string ip)
        {
            if (!checkip(ip))
                throw new ArgumentException("Eror");

            DayOfWeek popularDay = DayOfWeek.Friday;

            int count = 0;

            List<ipAddress> currentip = arrIp.Where(i => i.Ip == ip).ToList();

            for (int i = 0; i < 7; i++)
            {
                if (currentip.Where(j => ((int)j.Day == i + 1)).ToList().Count > count)
                {
                    popularDay = (DayOfWeek)(i + 1);
                    count = currentip.Where(j => ((int)j.Day == i + 1)).ToList().Count;
                }
            }

            return popularDay;
        }

       

        public int getpopularhour()
        {
            int count = 0;

            int hour = -1;

            for (int i = 0; i < 24; i++)
            {
                if (arrIp.Where(j => (j.Time.Hour == i)).ToList().Count > count)
                {
                    hour = i;
                    count = arrIp.Where(j => (j.Time.Hour == i)).ToList().Count;
                }
            }

            return hour;
        }


        public override string ToString()
        {
            string result = "";

            foreach (var item in arrIp)
            {
                result += item.ToString();
            }
            return result;
        }
    }

}
