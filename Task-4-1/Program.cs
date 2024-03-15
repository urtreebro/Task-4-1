using System;

namespace Task_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            OneDimensionalArray<string> array = new();
            array.Add("b");
            array.Add("a");
            array.Add("c");
            array.Print();
            array.Sort();
            array.Print();
            array.Reverse();
            array.Print();
        }
    }
}
