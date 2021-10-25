using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public delegate int Compare(object firstObject, object secondObject);

    class BubbleSort
    {
        public static void Sort(object[] arr, Compare compare)
        {
            bool flag = false;
            object tempObject = null;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                flag = false;

                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (compare(arr[j], arr[j + 1]) > 0)
                    {
                        tempObject= arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tempObject;

                       flag = true;
                    }
                }

                if (!flag)
                {
                    break;
                }
            }
        }
    }
}
