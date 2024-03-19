using System;

namespace Task_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            OneDimensionalArray<int> array = new();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Print();
            Func<int, bool> func = (x) => x %2==0;
            Console.WriteLine(array.Min());
        }
    }
}
