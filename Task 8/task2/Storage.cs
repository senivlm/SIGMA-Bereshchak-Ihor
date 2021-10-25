using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Storage: IEnumerable<Product>
    {
        private List<Product> products;
        (int, int, int) Koefs;
        bool IsInitialised = false;

        public Storage() { }
        
        public Product this[int Index]
        {
            get { return products[Index]; }
            set { products[Index] = value; }
        }

        public void ChangePrices(double npercentage)
        {
            foreach (var product in products)
            {
                product.ChangePrice(Percentage: npercentage, Koefs);
            }
        }

        public override string ToString()
        { 
            StringBuilder resultString = new StringBuilder();

            foreach (var product in products)
            {
                
                resultString.Append(product + "\n");
            }

            return resultString.ToString();

            
        }

        public List<Product> GetMeatProducts()
        {
            int countProducts = 0;

            for (int i = 0; i < products.Capacity; i++)
            {
                if (products[i] is Meat)
                {
                    countProducts++;
                }
            }
            
            List<Product> meats= new List<Product>(countProducts);
            countProducts = 0;

            for (int i = 0; i < products.Capacity; i++)
            {
                if (products[i] is Meat)
                {
                    meats[countProducts] = products[i];
                    countProducts++;
                }
            }

            return meats;
        }

        public void GetBadDairyProducts(string filePath)
        {
            string result = "";
            Dairy_products dairy = null;

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    for (int i = 0; i < products.Capacity; i++)
                    {
                        if ((dairy = products[i] as Dairy_products) != null)
                        {
                            if ((DateTime.Today - dairy.CreationTime).TotalDays > dairy.ExpirationDate)
                            {
                                result += $"{dairy.Name} {dairy.Weight} {dairy.Price} {dairy.ExpirationDate} {dairy.CreationTime}\n";
                                products[i] = null;
                            }
                        }
                    }

                    sw.Write(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get bad dairy products: " + ex.Message);
            }
        }


        public void AddFromFile(string filePath)
        {
            string[] sentence = null;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    sentence = sr.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    products = new List<Product>(sentence.Length - 1);
                    try
                    {
                        string[] koefs = sentence[0].Split();

                        Koefs.Item1 = Convert.ToInt32(koefs[0]);
                        Koefs.Item2 = Convert.ToInt32(koefs[1]);
                        Koefs.Item3 = Convert.ToInt32(koefs[2]);
                    }
                    catch (Exception exep)
                    {
                        throw new Exception("Bad koefs"+exep.Message);
                    }

                    string[] words = null;

                    try
                    {
                        for (int i = 1; i < sentence.Length; i++)
                        {
                            words = sentence[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                            switch (words[0])
                            {
                                case ("Meat"):
                                    products.Add(new Meat());
                                  
                                    break;
                                case ("Dairy"):
                                    products.Add(new Dairy_products());
                                   
                                    break;
                                case ("Classic"):
                                    products.Add(new Product());
                                    break;

                                default:
                                    throw new Exception("Bad product type");
                                    break;
                            }

                            products[i - 1].Parse(words[1]);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error initialisation stage: " + ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Initialisation from file failed: " + ex.Message);
            }

            IsInitialised = true;
        }
        /*
       public void StartFastInitialisation(int k1, int k2, int k3, params Product[] _paramsProducts)
        {
            if (IsInitialised)
            {
                return;
            }

            products = new List<Product>(_paramsProducts.Length);
            IsInitialised = true;
            for (int i = 0; i < _paramsProducts.Length; i++)
            {
                products[i] = _paramsProducts[i].Copy();
            }

            Koefs = (k1, k2, k3);
        }

        public void StartSlowInitialisation()
        {
            if (IsInitialised)
            {
                return;
            }

            Console.WriteLine("How much elemests shoud your storage have?");
            int Count = Convert.ToInt32(Console.ReadLine());
            this.products = new List<Product>();
            IsInitialised = true;

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"Prod #{i + 1}");
                Console.WriteLine("Which type of product do you want to insert?\n1.Classic\n2.Meat\n3.Dairy\n");
                string choice = Console.ReadLine();

                string name;
                int weight;
                double price;
                int expirationDate;
                DateTime creationTime;

                switch (choice)
                {
                    case ("Classic"):
                        try
                        {
                            Console.WriteLine("Input name");
                            name = Console.ReadLine();
                            Console.WriteLine("Input weight");
                            weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input price");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expiration date");
                            expirationDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input creation time");
                            creationTime = DateTime.Parse(Console.ReadLine());

                            products[i] = new Product(_name: name, _weight: weight, _price: price, _expirationDate: expirationDate, _creationTime: creationTime);
                        }
                        catch (Exception exx)
                        {
                            throw new Exception("Impossible to initialise 'Product' object: " + exx.Message);
                        }

                        break;


                    case ("Meat"):
                        try
                        {
                            Console.WriteLine("Input name");
                            name = Console.ReadLine();
                            Console.WriteLine("Input weight");
                            weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input price");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expiration date");
                            expirationDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input creation time");
                            creationTime = DateTime.Parse(Console.ReadLine());

                            Type t = 0;
                            Console.WriteLine("\nChoose type\nLamb\nVeal\nPork\nChicken\n");

                            switch (Console.ReadLine())
                            {
                                case ("Lamb"):
                                    t = Type.Lamb;
                                    break;
                                case ("Veal"):
                                    t = Type.Veal;
                                    break;
                                case ("Pork"):
                                    t = Type.Pork;
                                    break;
                                case ("Chicken"):
                                    t = Type.Chicken;
                                    break;
                            }
                            Console.WriteLine("\nChoose type\nGreatest\nFirst\nSecond\n");
                            Sort s = 0;
                            switch (Console.ReadLine())
                            {
                                case ("Greatest"):
                                    s = Sort.Greatest;
                                    break;
                                case ("First"):
                                    s = Sort.First;
                                    break;
                                case ("Second"):
                                    s = Sort.Second;
                                    break;
                            }

                            products[i] = new Meat(_name: name, _weight: weight, _price: price, _sort: s, _type: t, _expirationDate: expirationDate, _creationTime: creationTime);
                        }
                        catch (Exception exx)
                        {
                            throw new Exception("Impossible to initialise 'meat' object: " + exx.Message);
                        }
                        break;

                    case ("Dairy"):
                        try
                        {
                            Console.WriteLine("Input name");
                            name = Console.ReadLine();
                            Console.WriteLine("Input weight");
                            weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input price");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expire date");
                            int ex = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expiration date");
                            expirationDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input creation time");
                            creationTime = DateTime.Parse(Console.ReadLine());

                            products[i] = new Dairy_products(_name: name, _weight: weight, _price: price, _expirationDate: expirationDate, _creationTime: creationTime);
                        }
                        catch (Exception exx)
                        {
                            throw new Exception("Impossible to initialise 'dairy' object: " + exx.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        i--;
                        continue;
                }
            }

            int koef1, koef2, koef3;
            Console.WriteLine("\nInput koef #1:");
            koef1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nInput koef #2:");
            koef2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nInput koef #3:");
            koef3 = Convert.ToInt32(Console.ReadLine());

            Koefs = (koef1, koef2, koef3);
        }

        */

        IEnumerator IEnumerable.GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return new StorageEnumerator(products);
        }

        class StorageEnumerator : IEnumerator<Product>
        {
            private List<Product> listProducts = null;
            private int currentPosition = -1;

            public StorageEnumerator(List<Product> products)
            {
                listProducts = products;
            }

            public Product Current => listProducts[currentPosition];

            object IEnumerator.Current => listProducts[currentPosition];

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                currentPosition++;

                return currentPosition < listProducts.Count;
            }

            public void Reset()
            {
                currentPosition = 0;
            }
        }
    }
}
