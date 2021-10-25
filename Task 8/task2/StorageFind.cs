using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class StorageFind
    {
        public static List<Product> IntersectStorage(Storage storage1, Storage storage2)
        {
            HashSet<Product> FirstStorage = new HashSet<Product>(storage1);
            HashSet<Product> SecondStorage = new HashSet<Product>(storage2);

            FirstStorage.IntersectWith(SecondStorage);
            List<Product> products = new List<Product>(FirstStorage.Count);

            foreach (Product product in FirstStorage)
            {
                products.Add(product);
            }


            return products;
        }

        public static List<Product> FirstExceptSecond(Storage storage1, Storage storage2)
        {
            HashSet<Product> FirstStorage = new HashSet<Product>(storage1);
            HashSet<Product> SecondStorage = new HashSet<Product>(storage2);

            FirstStorage.ExceptWith(SecondStorage);
            List<Product> products = new List<Product>(FirstStorage.Count);

            foreach (Product product in FirstStorage)
            {
                products.Add(product);
            }


            return products;
        }

        public static List<Product> UnionStorage(Storage storage1, Storage storage2)
        {
            HashSet<Product> FirstStorage = new HashSet<Product>(storage1);
            HashSet<Product> SecondStorage = new HashSet<Product>(storage2);

            FirstStorage.UnionWith(SecondStorage);
            List<Product> products = new List<Product>(FirstStorage.Count);

            foreach (Product product in FirstStorage)
            {
                products.Add(product);
            }


            return products;
        }
        
    }
}
