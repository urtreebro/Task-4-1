using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    class BoolValueProvider : IValueProvider<bool>
    {
        public bool GetRandomValue()
        {
            bool[] bools = [true, false];
            return bools[new Random().Next(0, 2)];
        }

        public bool GetUserValue()
        {
            return bool.Parse(Console.ReadLine());
        }
    }
}
