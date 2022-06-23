using System;

namespace FileSystemFacade
{
    /// <summary>
    /// An interface to interact with a value in an atomic way.
    /// </summary>
    /// <typeparam name="TFileSystem">The type to which will be interacted with in an atomic way.</typeparam>
    public interface IAtomicActions<out TFileSystem>
    {
        /// <summary>
        /// Allows a non returning action to be performed on the TFileSystem.
        /// </summary>
        /// <param name="doer">An action that takes a TValue and acts on it.</param>
        void Preform(Action<TFileSystem> doer);
        
        /// <summary>
        /// Allows for an activity to be done on TFileSystem that also returns a value. 
        /// </summary>
        /// <param name="getter">A func that takes a type TValue and returns T.</param>
        /// <typeparam name="TReturn">The type to return.</typeparam>
        /// <returns>A type TReturn, that is returned from the getter.</returns>
        TReturn GetBy<TReturn>(Func<TFileSystem, TReturn> getter);
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