using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task_4_1
{
    sealed class OneDimensionalArray<T> : ArrayBase<T>
    {
        private int length;

        T[] array;

        public OneDimensionalArray(int capacity = 0) : base(capacity)
        {
            array = new T[capacity];
        }

        public int Length
        {
            get { return length; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public override void Print()
        {
            Console.WriteLine("Printed array:");
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public override void Add(T element) 
        {
            if (length >= capacity)
            {
                Resize();
            }
            array[length] = element;
            length++;
        }

        private void Resize()
        {
            capacity = capacity == 0 ? 4 : capacity * 2 + 1;
            T[] arrayTemp = new T[length];
            array.CopyTo(arrayTemp, 0);

            array = new T[capacity];
            arrayTemp.CopyTo(array, 0);
        }

        public override void Remove(T element) 
        {
            int index = Index(element);
            length--;

            Array.Copy(array, index + 1, array, index, length-index);
        }

        public override void ForEach(Action<T> action) 
        {
            for (int i = 0; i < length; i++)
            {
                action(array[i]);
            }
        }

        public override void Project<TResult>(Func<T, TResult> project) { }

        private int Index(T element)
        {
            for (int i = 0; i < length;i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }
            return -1; //add exception
        }

        public override void Sort()
        {
            IComparer<T> comparer = Comparer<T>.Default;
            for (int i = 1; i < length; i++)
            {
                int j = i;

                T k = array[i];

                while (j > 0 && comparer.Compare(array[j - 1], k) > 0)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = k;
            }
        }

        public override void Reverse()
        {
            T[] arrayTemp = new T[length];

            for (int i = 0; i < length; i++)
            {
                arrayTemp[length - i - 1] = array[i];
            }

            arrayTemp.CopyTo(array, 0);
        }

        public override T Min()
        {
            IComparer<T> comparer = Comparer<T>.Default;

            T min = array[0];

            for (int i = 1; i < length; i++)
            {
                if (comparer.Compare(array[i], min) == -1)
                {
                    min = array[i];
                }
            }
            return min;

        }

        public override T Max()
        {
            IComparer<T> comparer = Comparer<T>.Default;

            T max = array[0];

            for (int i = 1; i < length; i++)
            {
                if (comparer.Compare(array[i], max) == 1)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public override T[] GetByCondition(Func<T, bool> condition)
        {
            T[] arrayResult = new T[length];

            int index = 0;

            for (int i = 0; i < length; i++)
            {
                if (condition(array[i]))
                {
                    arrayResult[index++] = array[i];
                }
            }
            Array.Resize(ref arrayResult, index);
            return arrayResult;
        }

        public override int Count() => length;

        public override int CountByCondition(Func<T, bool> condition)
        {
            int counter = 0;

            for (int i = 0; i < length; i++)
            {
                if (condition(array[i]))
                {
                    counter++;
                }
            }
            return counter;
        }

        public override T[] Get(int index, int count)
        {
            T[] arrayResult = new T[count];

            array.CopyTo(arrayResult, index);

            return arrayResult;
        }

        public override T Find(Func<T, bool> condition)
        {
            for (int i = 0; i < length;i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            throw new Exception("No elements matched this condition");
        }
    }
}
