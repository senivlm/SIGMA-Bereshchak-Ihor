using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class Dairy_products:Product
    {
        private int expirationDate = 0;

        public Dairy_products(string nname, int nweight, double nprice, int nexpirationDate, DateTime ncreationTime) : base(nname, nweight, nprice, nexpirationDate, ncreationTime)
        { }

        public Dairy_products() : base() { }

       

        public override void ChangePrice(double Percentage, (int, int, int) Coefs)
        {
            base.ChangePrice(Percentage, Coefs);

            if (ExpirationDate < 7)
            {
                base.ChangePrice(Coefs.Item1, Coefs);
            }
            else if (ExpirationDate < 14 && ExpirationDate >= 7)
            {
                base.ChangePrice(Coefs.Item2, Coefs);
            }
            else if (ExpirationDate >= 14)
            {
                base.ChangePrice(Coefs.Item3, Coefs);
            }
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode() + Convert.ToInt32(Weight) + Convert.ToInt32(Price) + Convert.ToInt32(ExpirationDate) + CreationTime.Day;
        }

        public override bool Equals(Object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                var Second = (Dairy_products)obj;
                return this.Name == Second.Name &&this.Price == Second.Price &&this.Weight == Second.Weight && this.ExpirationDate == Second.ExpirationDate;
            }

           else return false;
        }
        public override void Parse(string dataSentence)
        {
            string[] words = dataSentence.Split();

            try
            {
                base.Parse(words[0] + ' ' + words[1] + ' ' + words[2] + ' ' + words[3] + ' ' + words[4]);
            }
            catch
            {
                throw;
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name} Weight: {this.Weight}, Price: {this.Price}, Expiration date: {this.ExpirationDate}";
        }

        public new Dairy_products Copy()
        {
            return (Dairy_products)this.MemberwiseClone();
        } 
    }
}
