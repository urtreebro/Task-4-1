using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    interface IBase<T> : IPrinter
    {
        void Refill(bool userInput = false);

        void Add(T element);

        void Remove(T element);

        void ForEach(Func<T> func);

        void Project<TResult>(Func<T, TResult> project);
    }
}
