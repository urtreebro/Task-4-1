using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    class StringValueProvider : IValueProvider<string>
    {
        private static Random rnd = new Random();
        public string GetRandomValue()
        {
            int n = rnd.Next(1, 10);
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string str = string.Empty;
            for (int i = 0; i < n; i++)
            {
                str += chars[rnd.Next(chars.Length)];
            }
            return str;
        }

        public string GetUserValue()
        {
            return Console.ReadLine();
        }
    }
}
