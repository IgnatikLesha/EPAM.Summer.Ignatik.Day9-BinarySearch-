using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
        public static class BinarySearchMethod
        {
            public static int BinarySearch<T>(T[] array, T elem, int leftIndex, int rightIndex, IComparer<T> comparer)
            {
            if (ReferenceEquals(array, null) || ReferenceEquals(comparer, null) || 
                ReferenceEquals(elem, null))
                throw new ArgumentException();

            Sort(array, comparer);

            int i = -1;

                int left = leftIndex, right = rightIndex, mid = (leftIndex + rightIndex) / 2;
                while (left != right)
                {
                    int temp = comparer.Compare(array[mid], elem);
                    if (temp > 0)
                    {
                        right = mid;
                        mid = (left + right) / 2;
                    }
                    if (temp < 0)
                    {
                        left = mid;
                        mid = (left + right) / 2;
                    }
                    if (temp == 0)
                        return mid;
                }
            
            return i;
            }

            public static int BinarySearch<T>(T[] array, T elem, IComparer<T> comparer)
            {
            if (ReferenceEquals(array, null) || ReferenceEquals(comparer, null) ||
                ReferenceEquals(elem, null))
                throw new ArgumentException();
            return BinarySearch(array, elem, 0, array.Length - 1, comparer);
            }

             public static int BinarySearch<T>(T[] array, T elem, Comparison<T> comparer)
             {
                  if (array == null)
                      throw new ArgumentNullException();
                  return BinarySearch(array, elem, 0, array.Length - 1, new Adapter<T>(comparer));
             }

             public static int BinarySearch<T>(T[] array, T elem, int leftIndex, int rightIndex, Comparison<T> comparer)
             {
                 if (array == null)
                     throw new ArgumentNullException();
                 return BinarySearch(array, elem, leftIndex, rightIndex, new Adapter<T>(comparer));
             }

        private static void Sort<T>(T[] array, IComparer<T> comparer)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < array.Length -  1; i++)
                {
                    if (comparer.Compare(array[i], array[i + 1]) > 0)
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        sorted = false;
                    }
                }
            }
        }

        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private class Adapter<T> : IComparer<T>
        {
            private readonly Comparison<T> comparison;

            public Adapter(Comparison<T> comparer)
            {
                comparison = comparer;
            }

            public int Compare(T lhs, T rhs)
            {
                return comparison(lhs, rhs);
            }
        }

    }

}

