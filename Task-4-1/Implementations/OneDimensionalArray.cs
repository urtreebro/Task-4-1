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
    sealed class OneDimensionalArray<T> : IArray<T>
    {
        private int length;

        T[] array;

        private int capacity;

        public OneDimensionalArray(int capacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(capacity);

            this.capacity = capacity;

            array = new T[capacity];
        }

        public OneDimensionalArray()
        {
            this.capacity = 0;

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

        public void Print()
        {
            Console.WriteLine("Printed array:");
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public void Add(T element) 
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

        public void Remove(T element) 
        {
            int index = Index(element);
            length--;

            Array.Copy(array, index + 1, array, index, length-index);
        }

        public void ForEach(Action<T> action) 
        {
            ArgumentNullException.ThrowIfNull(action);

            for (int i = 0; i < length; i++)
            {
                action(array[i]);
            }
        }

        public TResult[] Project<TResult>(Func<T, TResult> projector) 
        {
            ArgumentNullException.ThrowIfNull(projector);

            TResult[] arrayResult = new TResult[length];

            for (int i = 0; length > i; i++)
            {
                arrayResult[i] = projector(array[i]);
            }
            return arrayResult;
        }

        private int Index(T element)
        {
            for (int i = 0; i < length;i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }
            throw new Exception("No such element in array");
        }

        public void Sort()
        {
            Comparer<T> comparer = Comparer<T>.Default;
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

        public void Reverse()
        {
            T[] arrayTemp = new T[length];

            for (int i = 0; i < length; i++)
            {
                arrayTemp[length - i - 1] = array[i];
            }

            arrayTemp.CopyTo(array, 0);
        }

        public T Min()
        {
            Comparer<T> comparer = Comparer<T>.Default;

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

        public TResult Min<TResult>(Func<T, TResult> projector)
        {
            ArgumentNullException.ThrowIfNull(projector);

            Comparer<TResult> comparer = Comparer<TResult>.Default;

            TResult min = projector(array[0]);

            for (int i = 1; i < length; i++)
            {
                if (comparer.Compare(projector(array[i]), min) < 0)
                {
                    min = projector(array[i]);
                }
            }
            return min;
        }

        public T Max()
        {
            Comparer<T> comparer = Comparer<T>.Default;

            T max = array[0];

            for (int i = 1; i < length; i++)
            {
                if (comparer.Compare(array[i], max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public TResult Max<TResult>(Func<T, TResult> projector)
        {
            ArgumentNullException.ThrowIfNull(projector);

            Comparer<TResult> comparer = Comparer<TResult>.Default;

            TResult max = projector(array[0]);

            for (int i = 1; i < length; i++)
            {
                if (comparer.Compare(projector(array[i]), max) > 0)
                {
                    max = projector(array[i]);
                }
            }
            return max;
        }

        public T[] GetByCondition(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);

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

        public int Count() => length;

        public int CountByCondition(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);

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

        public T[] Get(int index, int count)
        {
            T[] arrayResult = new T[count];
            int index1 = 0;

            for (int i = index; i < count+1; i++)
            {
                arrayResult[index1++] = array[i];
            }
            return arrayResult;
        }

        public T Find(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);

            for (int i = 0; i < length;i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            throw new Exception("No elements matched this condition");
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IfAny(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);

            for (int i = 0; i < length; i++)
            {
                if (condition(array[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IfAll(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);

            for (int i = 0; i < length; i++)
            {
                if (!condition(array[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
