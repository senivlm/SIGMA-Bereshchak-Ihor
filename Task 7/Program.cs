using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "I go to school. Girl runs to school";
            Vocabulary my = new Vocabulary();
            sentence=my.change(sentence);
            Console.WriteLine('\n');
            Console.WriteLine(sentence);

        }
    }
}
