using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {

          Storage storage = new Storage();

            storage.InvalidProductInitialisationEvent += InvalidProductHandler.WriteLog;
            storage.InvalidProductInitialisationEvent += Storage.ConsoleReinitialisation;

            storage.SearchBadDairyProductsEvent += BadDairyProductHandler.LogWriteBadDairy;
            storage.SearchBadDairyProductsEvent += Storage.DeleteBadDairyProducts;




            storage.AddFromFile(@"D:\Sigma\DZ9\Task\task\task\TextFile1.txt");
            storage.SearchBadDairyProducts();

            Console.WriteLine();

            foreach (var product in storage)
            {
                Console.WriteLine(product);
            }
        }
    }
}
