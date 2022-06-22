using System;

namespace FileSystemFacade
{
    /// <summary>
    /// An interface to interact with a value in an atomic way.
    /// </summary>
    /// <typeparam name="TValue">The type to which will be interacted with in an atomic way.</typeparam>
    public interface IAtomicActions<TValue>
    {
        /// <summary>
        /// Allows a non returning action to be performed on the TValue.
        /// </summary>
        /// <param name="doer">An action that takes a TValue and acts on it.</param>
        void Preform(Action<TValue> doer);
        
        /// <summary>
        /// Allows for an activity to be done on TValue that also returns a value. 
        /// </summary>
        /// <param name="getter">A func that takes a type TValue and returns T.</param>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <returns>A type T, that is returned from the getter.</returns>
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