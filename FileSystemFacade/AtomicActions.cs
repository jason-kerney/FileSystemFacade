using System;

namespace FileSystemFacade
{
    public interface IAtomicActions<TValue>
    {
        void Preform(Action<TValue> doer);
        T GetBy<T>(Func<TValue, T> getter);
    }
    
    internal class AtomicActions<TValue> : IAtomicActions<TValue> where TValue : IDisposable
    {
        private readonly Func<TValue> builder;

        public AtomicActions(Func<TValue> builder)
        {
            this.builder = builder;
        }

        public void Preform(Action<TValue> doer)
        {
            using var value = builder();
            doer(value);
        }

        public T GetBy<T>(Func<TValue, T> getter)
        {
            using var value = builder();
            return getter(value);
        }
    }
    
    internal class AtomicPassThrough<TValue> : IAtomicActions<TValue>
    {
        private readonly Func<TValue> builder;

        public AtomicPassThrough(Func<TValue> builder)
        {
            this.builder = builder;
        }

        public void Preform(Action<TValue> doer)
        {
            doer(builder());
        }

        public T GetBy<T>(Func<TValue, T> getter)
        {
            return getter(builder());
        }
    }
}