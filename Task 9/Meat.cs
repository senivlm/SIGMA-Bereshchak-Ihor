using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{   
    enum Type
    {
        Pork,
        Lamb,
        Chicken,   
        Veal 
    }
    enum Sort
    {
        Great = 0,
        First = 1,
        Second = 2
    }

    
    class Meat:Product
    {   
        private Sort sortProduct;
        public Sort SortProduct
        {
            get
            {
                return sortProduct; 
            }
            protected set
            {
                try
                {
                    sortProduct = value;
                }
                catch (System.Exception exep)
                {
                    Console.Write(exep.Message);
                }
            }
        }
        private Type typeProduct;
        public Type TypeProduct
        {
            get 
            {
                return typeProduct; 
            }
            protected set
            {
                try
                {
                    typeProduct = value;
                }
                catch (System.Exception exep)
                {
                    Console.Write(exep.Message);
                }
            }
        }
        public Meat(string nname, int nweight, double nprice, int nexpirationDate, DateTime ncreationTime, Sort nsort, Type ntype) :base(nname, nweight, nprice, nexpirationDate, ncreationTime)
        {
            this.SortProduct = nsort;
            this.TypeProduct = ntype;
        }

        public Meat() : base() 
        { this.SortProduct = Sort.Second;
          this.TypeProduct = Type.Veal; 
        }

        public override void Parse(string dataSentence)
        {
            string[] words = dataSentence.Split();

            try
            {
                base.Parse(words[0] + ' ' + words[1] + ' ' + words[2] + ' ' +words[3] + ' ' + words[4]);
            }
            catch (Exception exep)
            {
                throw exep;
            }

            try
            {
                this.SortProduct = (Sort)Enum.Parse(typeof(Sort), words[5]);
            }
            catch (Exception exep)
            {
                throw new  Exception("Error with sort product parameter" + exep.Message); ;
            }
            try
            {
                this.TypeProduct = (Type)Enum.Parse(typeof(Type), words[6]);
            }
            catch (Exception exep)
            {
                throw new Exception("Error with type product parameter" + exep.Message); ;
            }


        }

        public override void ChangePrice(double Percentage, (int, int, int) Coefs)
        {
            base.ChangePrice(Percentage, Coefs);

            if (SortProduct == Sort.Great)
            {
                base.ChangePrice(Coefs.Item1, Coefs);
            }
            else if (SortProduct == Sort.First)
            {
                base.ChangePrice(Coefs.Item2, Coefs);
            }
            else if (SortProduct == Sort.Second)
            {
                base.ChangePrice(Coefs.Item3, Coefs);
            }
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode() + Convert.ToInt32(Weight) +Convert.ToInt32(Price) + Convert.ToInt32(ExpirationDate) + Convert.ToInt32(SortProduct) + Convert.ToInt32(typeProduct) + CreationTime.Day;
        }

        public override bool Equals(Object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                var Second = (Meat)obj;
                return this.Name == Second.Name &&this.Price == Second.Price && this.Weight == Second.Weight &&this.SortProduct == Second.SortProduct && this.TypeProduct == Second.TypeProduct;
            }

            else return false;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Weight: {this.Weight}, Price: {this.Price}, Sort: {this.SortProduct}, Type:{this.TypeProduct}";
        }

        public new Meat Copy()
        {
            return (Meat)this.MemberwiseClone();
        }

    }
}
