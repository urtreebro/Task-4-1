using System;

namespace Task_4_1
{
    class Program
    {
        static void Main()
        {
            OneDimensionalArray<int> array1 = new();

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                array1.Add(rnd.Next(0, 101)); 
            }

            array1.Print();

            Console.WriteLine($"\nMax: {array1.Max()}");
            Console.WriteLine($"\nMin: {array1.Min()}");

            Console.WriteLine($"\nFirst even element: {array1.Find(x => x % 2 == 0)}");

            Console.WriteLine("\nAll odd elements:");
            Print(array1.GetByCondition(x => x % 2 != 0));

            Console.Write("\nSorted ");
            array1.Sort();
            array1.Print();

            Console.Write("\nReversed ");
            array1.Reverse();
            array1.Print();

            OneDimensionalArray<string> array2 = new();

            array2.Add("apple");
            array2.Add("peach");
            array2.Add("pineapple");
            array2.Add("grapes");
            array2.Add("pear");

            array2.Sort(); 
            Console.WriteLine();
            array2.Print();

            Console.WriteLine($"\nLength before removal: {array2.Length}");
            array2.Remove("grapes");
            Console.WriteLine($"\nLength after removal: {array2.Length}");

            Console.WriteLine($"\nDoes array contain grapes?: {array2.Contains("grapes")}\n");

            array2.Print();

            Console.WriteLine("\nElements from 1 to 2:");
            Print(array2.Get(1, 2));
            Console.WriteLine("\nAre all elements' lengths less than 7?:");
            Console.WriteLine(array2.IfAll(x => x.Length < 7));
        }

        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Print(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
