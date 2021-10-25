using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
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
       

    }
}
