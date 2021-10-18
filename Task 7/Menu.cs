using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    struct Weightprice {
        public double weight;
        public int price;
        public void AddWeight(double temp)
        {
           this.weight =weight+ temp;
        }
    };

    class Menu
    {
        public Dictionary<string, Weightprice> data;

        public Menu()
        {
            data = new Dictionary<string, Weightprice>();
        }
        public bool Addnew(string str,double nweight)
        {
            if (check(str) == false)
            {
                data.Add(str, new Weightprice() { weight = nweight });
                return true;
            }
            return false;
        }
        public bool Addnew(string str, int nprice)
        {
            if (check(str) == false)
            {
                data.Add(str, new Weightprice() { price = nprice });
                return true;
            }
            return false;
        }


        public void Add(string filepath)
        {

            StreamReader reader = new StreamReader(filepath);

            string[] text = reader.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < text.Length; i++)
            {
                string[] words = text[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 2)
                {

                    double temp;
                    int itemp;
                    if (double.TryParse(words[1], out temp)) {
                        if (check(words[0]) == false)
                        {
                            Addnew(words[0], temp);
                        }
                        else
                        {
                            data[words[0]] = new Weightprice() {weight= data[words[0]].weight+temp,price= data[words[0]].price};
                        }
                    }
                    
                    
                }
            }

            reader.Close();
        }





        public bool check(string str)
        {
            return data.ContainsKey(str);
        }
        public override string ToString()
        {
            string result = "";

            foreach (var item in data)
            {
                result += item.Key+" "+item.Value.weight+'\n';
            }
            return result;
        }
    }
}
