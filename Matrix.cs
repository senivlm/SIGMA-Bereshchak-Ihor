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
            return new Enumerator(data[][]);
        }
        class Enumerator : IEnumerator<Matrix>
        {
            int position = -1;
            private double[,] data;

            public Enumerator(Product[] products)
            {
                this.products = products;
            }
            public Product Current => products[position];

            object IEnumerator.Current => products[position];

            Matrix IEnumerator<Matrix>.Current => throw new NotImplementedException();

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (position + 2 < data[].Length)
                {
                    position += 2;
                    return true;
                }
                return false;

            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}
