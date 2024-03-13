using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    class DoubleValueProvider : IValueProvider<double>
    {
        private static Random rnd = new Random();
        public double GetRandomValue()
        {
            return rnd.NextDouble() * rnd.Next(1, 100);
        }

        public double GetUserValue()
        {
            return double.Parse(Console.ReadLine());
        }
    }
}
