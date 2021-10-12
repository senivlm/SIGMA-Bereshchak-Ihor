using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz
{
    class Polynom
    {
         public double[] koef;
    

        public Polynom()
        {
            koef = new double[1];
          
        }
        public Polynom(int k)
        {
            koef = new double[k+1];
        }
        public Polynom(double val)
        {
            koef = new double[1];
            koef[0] = val;
        }
        public Polynom(int k,double [] koefs)
        {
            koef = new double[k + 1];
            koef = koefs;
        }
        public static implicit operator Polynom(double x)
        {
            return new Polynom(x);
        }

        public double this[int index] {

            get
            {

                return koef[index];
            }
            set
            {
                if (value != 0)
                {
                    if (index < koef.Length)
                    {
                        koef[index] = value;
                    }
                    else
                    {
                        Array.Resize(ref koef, index + 1);
                        koef[index] = value;
                    }

                }
               if(value == 0)
                {
                    if (index < koef.Length)
                    {
                        koef[index] = 0;
                    }
                    else{
                       
                    }
                }


            }
        
        }
        public static Polynom operator +(Polynom A, Polynom B)
        {
            int Cl= A.koef.Length-1;
            Polynom C = new Polynom(Cl);
            for (int i = 0; i < A.koef.Length ; i++)
            {
                C.koef[i] = A.koef[i] + B.koef[i];
            }
            return C;
        }


       
        public static Polynom operator -(Polynom A, Polynom B)
        {
            int Cl = A.koef.Length-1;
            Polynom C = new Polynom(Cl);
            for (int i = 0; i < A.koef.Length; i++)
            {
                C.koef[i] = A.koef[i] - B.koef[i];
            }
            return C;
        }


        public static Polynom operator *(Polynom A, Polynom B)
        {
            int Cl = A.koef.Length-1;
            Polynom C = new Polynom(Cl);
            for (int i = 0; i < A.koef.Length; i++)
            {
                C.koef[i] = A.koef[i] * B.koef[i];
            }
            return C;
        }



       /* public void Parse(string s)
        {
            char[] separators = { '+' };
            string[] monomial = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if ((monomial.Length - 1 != s.Count(ch => ch == '^'))
                ||
                (monomial.Length - 1 != s.Count(ch => ch == '*')))
            {
                throw new FormatException("Invalid parameters\n");
            }
            separators = new char[] { '^' };
            string[] sMonomial = monomial[monomial.Length - 1].Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (sMonomial.Length != 2)
            {
                throw new FormatException("Invalid parameters\n");
            }

            int tempDeegre = int.Parse(sMonomial[1]);
            if (tempDeegre > polinomDegree) { cIndex = new double[tempDeegre + 1]; polinomDegree = tempDeegre; }
            cIndex[0] = double.Parse(monomial[0]);
            char[] separatorMult = new char[] { '*' };
            int curDeegre;

            for (int i = 1; i < monomial.Length; i++)
            {
                sMonomial = monomial[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (sMonomial.Length != 2)
                {
                    throw new FormatException("Invalid parameters\n");
                }
                curDeegre = int.Parse(sMonomial[1]);
                sMonomial = monomial[i].Split(separatorMult, StringSplitOptions.RemoveEmptyEntries);
                if (sMonomial.Length != 2)
                {
                    throw new FormatException("Invalid parameters\n");
                }
                cIndex[curDeegre] = double.Parse(sMonomial[0]);
            }

        }*/
    }
}
