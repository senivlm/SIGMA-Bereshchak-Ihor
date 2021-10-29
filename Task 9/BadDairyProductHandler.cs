using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    public delegate void GetBadDairyProductsHandler(object sender, string message);

    class BadDairyProductHandler
    {
        public static void LogWriteBadDairy(object sender, string message)
        {
            string filePath = @"D:\Sigma\DZ9\Task\task\task\log.txt";

            StreamWriter sw = new StreamWriter(filePath, true);

            sw.WriteLine($"Delete  products :{message}. \n Time : {DateTime.UtcNow}");

            sw.Close();
        }

    }
}
