using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    class Vocabulary
    {
        Dictionary<string, string> data;

        public Vocabulary()
        {
            data = new Dictionary<string, string>();
            data.Add("I", "Boy");
            data.Add("go", "run");
            data.Add("to", "to");
            data.Add("school", "cinema");
        }
        public bool AddNew(string str)
        {
            if (check(str) == false)
            {
                string temp;
                Console.WriteLine($"Write word substitude:{str}");
                temp=Console.ReadLine();
                data.Add(str, temp);
                return true;
            }
            return false;
        }
        public bool check(string str)
        {
            return data.ContainsKey(str);
        }
        public string changeword(string str)
        {
            return data[str];
        }
        public string change(string text)
        {
            string temp = "";
            string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < sentences.Length; i++)
            {
                string[] words = sentences[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < words.Length; j++)
                {
                    if (check(words[j]) == false) AddNew(words[j]);
                    temp += changeword(words[j])+' ';
                }
                temp += '.';
 
            }

            return temp;
        }

    }
}
