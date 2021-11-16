using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
   
    class Storage: IEnumerable<Product>
    {
        private List<Product> products;
        (int, int, int) Koefs;
        bool IsInitialised = false;

        public event GetBadDairyProductsHandler SearchBadDairyProductsEvent;
        public event InvalidProduct InvalidProductInitialisationEvent;

        public Storage() { }
        
        public Product this[int Index]
        {
            get { return products[Index]; }
            set { products[Index] = value; }
        }


        public void AddProduct(Product product)
        {
          
            if (product == null)
            {
               
                InvalidProductInitialisationEvent?.Invoke(this, "Product == null");
                return;
            } 
            else products.Add(product);
        }
       

        public void DeleteProductByName(string productName)
        {
            List<Product> productsWithThisName = products.FindAll(product => (product.Name == productName));
            if (productsWithThisName == null)
            {
                throw new Exception($"No { productName } in products ");
            }
            else
            {
                products.RemoveAll((product) => productsWithThisName.Contains(product));
            }
        }
        public void DeleteProduct(Product product)
        {
            
            if (product == null)
            {
               
            }
            else
            {
                products.Remove(product);
            }
        }

        public List<Product> SearchProducts(string attribute, string value) 
        {

            List<Product> desiredProducts = new List<Product>();

            try
            {
                switch (attribute)
                {
                    case ("Name"):
                        desiredProducts.AddRange(products.FindAll((p) => (p.Name == value)));
                        break;
                    case ("Weight"):
                        desiredProducts.AddRange(products.FindAll((p) => (p.Weight == Int32.Parse(value ))));
                        break;
                    case ("Price"):
                        desiredProducts.AddRange(products.FindAll((p) => (p.Price == double.Parse(value))));
                        break;

                    default:
                        break;
                }
            }
            catch { }

            return desiredProducts;
        }
        public void SearchBadDairyProducts()
        {
            List<Dairy_products> badDairyProducts = new List<Dairy_products>();
            Dairy_products currentProduct = null;
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < products.Count; i++)
            {
                if ((currentProduct = products[i] as Dairy_products) != null)
                {
                    if ((DateTime.Today - currentProduct.CreationTime).TotalDays > currentProduct.ExpirationDate)
                    {
                        badDairyProducts.Add(currentProduct);
                        resultString.Append(currentProduct.Name + ",");
                    }
                }
            }

            foreach (Dairy_products dairyProduct in badDairyProducts)
            {
                products.Remove(dairyProduct);
            }

            SearchBadDairyProductsEvent?.Invoke( this,resultString.ToString());
        }
        public static void DeleteBadDairyProducts(object sender, string names)
        {
            string[] name = names.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
// Проблемне місце. 1. Цей обробник мав би бути в іншому класі.2. При приведенні до типу треба перевіряти, чи можна привести за допомогою операції is
            Storage storage = (Storage)sender;
            for (int i = 0; i < name.Length; i++)
            {
               storage.DeleteProductByName(name[i]);
            }
        }
        public static void ConsoleReinitialisation(object sender, string incorrectProduct)
        {
            Storage storage = (Storage)sender;
            if (incorrectProduct != null)
            {
                Console.WriteLine($" {incorrectProduct}. Please initialise now");
            }

            string typeProduct = null;
            storage.products.Add(null);
            Console.WriteLine("Enter type of the Product:");
            while (true)
            {
                typeProduct = Console.ReadLine();
                if (typeProduct == "Product")
                {
                    storage.products[storage.products.Count - 1] = new Product();
                    break;
                }
                else if (typeProduct == "Meat")
                {
                    storage.products[storage.products.Count - 1] = new Meat();
                    break;
                }
                else if (typeProduct == "Dairy")
                {
                    storage.products[storage.products.Count - 1] = new Dairy_products();
                    break;
                }
                else
                {
                    Console.WriteLine("Bad type of Product,try again.");
                }
            }


            Console.WriteLine("Write name");
            string newName = Console.ReadLine();

            Console.WriteLine("Write weight o");
            int newWeight = 0;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out newWeight))
                {
                    break;
                }

                Console.WriteLine("Try again");
            }


            Console.WriteLine("Write price");
            double newPrice = 0;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out newPrice))
                {
                    break;
                }

                Console.WriteLine("Try again");
            }


            Console.WriteLine("Write  expiration date ");
            int newExpirationDate = 0;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out newExpirationDate))
                {
                    break;
                }

                Console.WriteLine("Try again");
            }


            Console.WriteLine("Write creation date");
            string newCreationDate = "";
            DateTime creationDate;
            while (true)
            {
                newCreationDate = Console.ReadLine();
                if (DateTime.TryParse(newCreationDate, out creationDate))
                {
                    break;
                }

                Console.WriteLine("Try again");

            }


            if (typeProduct == "Product" || typeProduct == "Dairy")
            {
                storage.products[storage.products.Count - 1].Parse($"{newName}{newWeight}{newPrice}{newExpirationDate}{newCreationDate}");
            }
            else
            {
                Console.WriteLine("Write type of meat  ");
                string typeMeat = Console.ReadLine();
                while ( typeMeat != "Chicken" && typeMeat != "Veal" && typeMeat != "Pork" && typeMeat != "Lamb")
                {
                    Console.WriteLine("Try again");
                    typeMeat = Console.ReadLine();
                }


                Console.WriteLine("Write sort of meat  ");
                string sortMeat = Console.ReadLine();
                while (sortMeat != "Great" && sortMeat != "First" && sortMeat != "Second")
                {
                    Console.WriteLine("Try again");
                    sortMeat = Console.ReadLine();
                }

                storage.products[storage.products.Count - 1].Parse($"{newName}{newWeight}{newPrice}{newExpirationDate}{newCreationDate} {sortMeat} {typeMeat}");
            }
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
                                case ("Product"):
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
              //  throw new Exception("Initialisation from file failed: " + ex.Message);
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
