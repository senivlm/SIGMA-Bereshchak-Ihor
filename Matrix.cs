using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz
{
    class Matrix :System.Collections.IEnumerable
    {
        private double[,] data;

        private int m;
        public int M {
            get => this.m; set
            {
                m = value;
            }
        }

        private int n;
        public int N
        {
            get => this.n; set
            {
                n = value;
            }
        }
        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
        }

     
        public IEnumerator GetEnumerator()
        {
            return new Enumerator();
        }
        
    }
}
