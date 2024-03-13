using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_1
{
    abstract class ArrayBase<T> : IBase<T>
    {
        protected bool userInput = false;

        protected static Random rnd = new();

        protected IValueProvider<T> _valueProvider;

        protected ArrayBase(IValueProvider<T> _valueProvider, bool userInput = false)
        {
            this.userInput = userInput;

            this._valueProvider = _valueProvider;

            Refill(userInput);
        }

        protected abstract void RandomInput();

        protected abstract void UserInput();

        public abstract void Print();

        public abstract void Refill(bool userInput = false);

        public abstract void Add(T element);

        public abstract void Remove(T element);

        public abstract void ForEach(Func<T> func);

        public abstract void Project<TResult>(Func<T, TResult> project);
    }
}
