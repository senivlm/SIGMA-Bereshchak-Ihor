using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    public delegate void InvalidProduct( object sender,string problemDescription);
    class InvalidProductHandler
    {
        public static void WriteLog(object sender,string message)
        {
            string logFilePath = @"D:\Sigma\DZ9\Task\task\task\log.txt";

        StreamWriter sw = new StreamWriter(logFilePath, true);
        sw.WriteLine($"Incorect Product :{message} Time - {DateTime.UtcNow}");

            sw.Close();
        }
}
}
