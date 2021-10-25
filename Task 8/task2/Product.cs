using System;

namespace task2
{
    class Product
    {

        int expirationDate;
        public int ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                if (value > 0)
                {
                    expirationDate = value;
                }
            }
        }


        private DateTime creationTime;
        public DateTime CreationTime
        {
            get { return creationTime; }
            private set { creationTime = value; }
        }



        private string name;
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        private int weight;
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value >= 0)
                {
                    weight = value;
                }
            }
        }


        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    price = (-1) * value;
                }
                else
                {
                    price = value;
                }
            }
        }

        public Product(string nname, int nweight, double nprice, int nexpirationDate, DateTime ncreationTime)
        {
            this.name = nname;
            this.price = nprice;
            this.weight = nweight;
            this.expirationDate = nexpirationDate;
            this.creationTime = ncreationTime;
        }

        public Product() : this(nname: "Name", nweight: 0, nprice: 0, nexpirationDate: 1, ncreationTime: DateTime.Now) { }





        public override int GetHashCode()
        {
            return Name.GetHashCode() + Convert.ToInt32(Weight) + Convert.ToInt32(Price) + ExpirationDate + CreationTime.Day;
        }

        public virtual void ChangePrice(double Percentage, (int, int, int) Koefs)
        {

            Price *= 1 + (Percentage / 100);
            Price = Math.Round(Price, 2);
        }

        public override bool Equals(Object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                var Second = (Product)obj;
                return this.Name == Second.Name && this.Price == Second.Price && this.Weight == Second.Weight;
            }

            return false;
        }


        public override string ToString()
        {
            return $"Name:{this.Name}, Weight: {this.Weight}, Price:{this.Price}";
        }

        public Product Copy()
        {
            return (Product)this.MemberwiseClone();
        }

        public virtual void Parse(string dataSentence)
        {
            string[] words = dataSentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length != 5)
            {
                throw new Exception($"Impossible to initialise {this.GetType()} object - invalid string for parse");
            }

            this.Name = words[0];

            try
            {
                this.Weight = Convert.ToInt32(words[1]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error with weight parameter" + ex.Message);
            }
            try
            {
                this.Price = Convert.ToDouble(words[2]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error with price parameter" + ex.Message);
            }
            try
            {
                this.ExpirationDate = Convert.ToInt32(words[3]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error with expiration date parameter" + ex.Message);
            }
            try
            {
                this.CreationTime = DateTime.Parse(words[4]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error with creation time parameter" + ex.Message);
            }
        }
    }
}
