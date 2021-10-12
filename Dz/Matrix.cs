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
        private int rowPosition, columnPosition;

        public object Current => data[rowPosition, columnPosition];
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



        public bool MoveNext()
        {
            --columnPosition;
            if (columnPosition < 0)
            {
                --rowPosition;
                columnPosition = n - 1;
            }
            return rowPosition >= 0 && columnPosition >= 0;
        }

        public void Reset()
        {
            rowPosition = m- 1;
            columnPosition = n;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
