using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        public static int SortByName(object firstObject, object secondObject)
        {
            Product product1 = (Product)firstObject;
            Product product2 = (Product)secondObject;

            if (product1 == null || product2 == null)
            {
                throw new Exception("Parameter is not a product");
            }

            return String.Compare(product1.Name, product2.Name);

        }

        public static int SortByWeight(object first, object second)
        {
            Product product1 =(Product) first ;
            Product product2 = (Product)second ;

            if (product1 == null || product2 == null)
            {
                throw new Exception("Parameter is not a product");
            }

            if (product1.Weight > product2.Weight)
            {
                return 1;
            }
            else if (product1.Weight < product2.Weight)
            {
                return -1;
            }
            else
            {
                return 0;
            }


        }
        static void Main(string[] args)
        {
           

            Product[] arrProduct = new Product[5];
            arrProduct[0] = new Product("Wheat", 310, 8.99, 20, new DateTime(2021, 10, 25));
            arrProduct[1] = new Product("Rice", 400, 4.5, 10, new DateTime(2021, 10, 24));
            arrProduct[2] = new Product("Muesli", 120, 12.5, 20, new DateTime(2021, 10, 23));
            arrProduct[3] = new Product("Flour", 500, 4.99, 10, new DateTime(2021, 10, 22));
            arrProduct[4] = new Product("Cookie", 50, 9.5, 5, new DateTime(2021, 10, 21));
            Console.WriteLine("Before");
            foreach (var product in arrProduct)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Sort by name");
            BubbleSort.Sort(arrProduct, SortByName);
            foreach (var product in arrProduct)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Sort by weight");

            BubbleSort.Sort(arrProduct, SortByWeight);

            foreach (var product in arrProduct)
            {
                Console.WriteLine(product);
            }
        }
    }
}
