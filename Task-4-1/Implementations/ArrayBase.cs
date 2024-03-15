using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    abstract class ArrayBase<T> : IBase<T>
    {
        protected static Random rnd = new();

        protected int capacity;

        protected ArrayBase(int capacity)
        {
            this.capacity = capacity;
        }

        public abstract void Print();

        public abstract void Add(T element);

        public abstract void Remove(T element);

        public abstract void ForEach(Func<T> func);

        public abstract void Project<TResult>(Func<T, TResult> project);

        public abstract void Sort();

        public abstract void Reverse();
    }
}
