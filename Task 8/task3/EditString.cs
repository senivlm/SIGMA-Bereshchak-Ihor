using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class EditString
    {
Все збито в одну купу. Цей метод треба ділити. І не повнісю враховано умову задачі
        public static string MostBrackets(string filePath)
        {
            StreamReader sr =new StreamReader(filePath);
            


            string result = "";
            string current = "";
            bool setNewSentance = false;

            int max = 0;
            int count = 0;

            string sentence = sr.ReadLine();
            while (sentence != null)
            {
                foreach (char letter in sentence)
                {
                    if (letter == '.')
                    {
                        current += letter;
                        if (setNewSentance)
                        {
                            result = current;
                        }

                        current = "";
                      
                        setNewSentance = false;
                    }
                    else if (letter == '(')
                    {
                        count++;
                        current += letter;
                    }
                    else if (letter == ')')
                    {
                        if (count > max)
                        {
                            setNewSentance = true;
                            max = count;
                        }

                        current += letter;
                        count--;
                    }
                    else
                    {
                        current += letter;
                    }
                }

                sentence = sr.ReadLine();
            }


            sr.Close();
            return result;
        }

        public static List<string> SortString(string filePath)
        {
            StreamReader streamReader =new StreamReader(filePath);
            List<string> listStrings = new List<string>();
            string current = "";
            string line = streamReader.ReadLine();
            while (line != null)
            {
                foreach (char letter in line)
                {
                    current += letter;

                    if (letter == '.')
                    {
                        listStrings.Add(current);
                        current = "";
                    }
                }
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            listStrings.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            return listStrings;
        }
    }
}
