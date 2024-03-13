using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    sealed class OneDimensionalArray<T> : ArrayBase<T>
    {
        private int n;

        T[] array;

        public OneDimensionalArray(IValueProvider<T> _valueProvider, bool userInput = false) : base(_valueProvider, userInput) { }

        public int Length
        {
            get { return n; }
        }

        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        protected override void RandomInput()
        {
            n = rnd.Next(1, 10);

            array = new T[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = _valueProvider.GetRandomValue();
            }
        }

        protected override void UserInput()
        {
            Console.WriteLine("Input length of the array");

            n = int.Parse(Console.ReadLine());

            array = new T[n];

            Console.WriteLine($"Input {n} values");

            for (int i = 0; i < n; i++)
            {
                array[i] = _valueProvider.GetUserValue();
            }
        }

        public override void Print()
        {
            Console.WriteLine("Printed array:");
            Console.WriteLine(string.Join(" ", array));
        }

        public override void Refill(bool userInput = false)
        {
            if (userInput)
            {
                UserInput();
            }
            else
            {
                RandomInput();
            }
        }

        public override void Add(T element) { }

        public override void Remove(T element) { }

        public override void ForEach(Func<T> func) { }

        public override void Project<TResult>(Func<T, TResult> project) { }
    }
}
