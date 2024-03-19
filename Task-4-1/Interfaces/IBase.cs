using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    interface IBase<T> : IPrinter
    {
        void Add(T element);

        void Remove(T element);

        void ForEach(Action<T> action);

        void Project<TResult>(Func<T, TResult> project);

        void Sort();

        void Reverse();

        T[] Get(int index, int count);

        int Count(); //make a lambda func

        int CountByCondition(Func<T, bool> condition);

        T Max();
        
        T Min();

        T Find(Func<T, bool> condition);

        T[] GetByCondition(Func<T, bool> condition);

    }
}
