using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class StorageFind
    {/*
        public static class ProductComparator
        { 
            
            public class CompareByName : IComparer<Product>
            {
                public int Compare( Product first, Product second)
                {
                    return first.Name.CompareTo(second.Name);
                }
            }
            public class CompareByPrice : IComparer<Product>
            {
                public int Compare( Product first,  Product second)
                {
                    if (first.Price > second.Price)
                    {
                        return 1;
                    }
                    else if (first.Price < second.Price)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

           
        }


        public delegate int ProductComparatorOption( Product first,  Product second);

        public class ReturnComparer : IComparer<Product>
        {
            private ProductComparatorOption ComparionOption = null;

            public ReturnComparer(ProductComparatorOption _option)
            {
                ComparionOption = _option;
            }

            public int Compare( Product x, Product y)
            {
                return ComparionOption(x, y);
            }
        }


        
        public static List<Product> GetCommonSortedProducts(Storage storage1, Storage storage2, IComparer<Product> comparer)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, comparer);
            var productsOfSecondStorage = new SortedSet<Product>(storage2, comparer);

            productsOfFirstStorage.IntersectWith(productsOfSecondStorage);
            List<Product> commonProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                commonProducts.Add(product);
            }


            return commonProducts;
        }

        public static List<Product> GetUniqueSortedProductsOfStorage(Storage storage1, Storage storage2, IComparer<Product> comparer)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, comparer);
            var productsOfSecondStorage = new SortedSet<Product>(storage2, comparer);

            productsOfFirstStorage.ExceptWith(productsOfSecondStorage);
            List<Product> uniqueProductsOfStorage = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                uniqueProductsOfStorage.Add(product);
            }


            return uniqueProductsOfStorage;
        }

        public static List<Product> GetAllSortedProducts(Storage storage1, Storage storage2, IComparer<Product> comparer)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, comparer);
            var productsOfSecondStorage = new SortedSet<Product>(storage2, comparer);

            productsOfFirstStorage.UnionWith(productsOfSecondStorage);
            List<Product> allProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                allProducts.Add(product);
            }


            return allProducts;
        }

       
        public static List<Product> GetCommonSortedProductsDelegate(Storage storage1, Storage storage2, ProductComparatorOption deleg)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, new ReturnComparer(deleg));
            var productsOfSecondStorage = new SortedSet<Product>(storage2, new ReturnComparer(deleg));

            productsOfFirstStorage.IntersectWith(productsOfSecondStorage);
            List<Product> commonProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                commonProducts.Add(product);
            }


            return commonProducts;
        }

        public static List<Product> GetUniqueSortedProductsOfStorageDelegate(Storage storage1, Storage storage2, ProductComparatorOption deleg)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, new ReturnComparer(deleg));
            var productsOfSecondStorage = new SortedSet<Product>(storage2, new ReturnComparer(deleg));

            productsOfFirstStorage.ExceptWith(productsOfSecondStorage);
            List<Product> uniqueProductsOfStorage = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                uniqueProductsOfStorage.Add(product);
            }


            return uniqueProductsOfStorage;
        }

        public static List<Product> GetAllSortedProductsDelegate(Storage storage1, Storage storage2, ProductComparatorOption deleg)
        {
            var productsOfFirstStorage = new SortedSet<Product>(storage1, new ReturnComparer(deleg));
            var productsOfSecondStorage = new SortedSet<Product>(storage2, new ReturnComparer(deleg));

            productsOfFirstStorage.UnionWith(productsOfSecondStorage);
            List<Product> allProducts = new List<Product>(productsOfFirstStorage.Count);

            foreach (Product product in productsOfFirstStorage)
            {
                allProducts.Add(product);
            }


            return allProducts;
        }

       */
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
