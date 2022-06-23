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
        /// <param name="doer">An action that takes a TFileSystem and acts on it.</param>
        void Preform(Action<TFileSystem> doer);
        
        /// <summary>
        /// Allows for an activity to be done on TFileSystem that also returns a value. 
        /// </summary>
        /// <param name="getter">A func that takes a type TFileSystem and returns TReturn.</param>
        /// <typeparam name="TReturn">The type to return.</typeparam>
        /// <returns>A type TReturn, that is returned from the getter.</returns>
        TReturn GetBy<TReturn>(Func<TFileSystem, TReturn> getter);
    }
    
    internal class AtomicActions<TFileSystem> : IAtomicActions<TFileSystem> where TFileSystem : IDisposable
    {
        private readonly Func<TFileSystem> builder;

        public AtomicActions(Func<TFileSystem> builder)
        {
            this.builder = builder;
        }

        public void Preform(Action<TFileSystem> doer)
        {
            using var value = builder();
            doer(value);
        }

        public TReturn GetBy<TReturn>(Func<TFileSystem, TReturn> getter)
        {
            using var value = builder();
            return getter(value);
        }
    }
    
    internal class AtomicPassThrough<TFileSystem> : IAtomicActions<TFileSystem>
    {
        private readonly Func<TFileSystem> builder;

        public AtomicPassThrough(Func<TFileSystem> builder)
        {
            this.builder = builder;
        }

        public void Preform(Action<TFileSystem> doer)
        {
            doer(builder());
        }

        public TReturn GetBy<TReturn>(Func<TFileSystem, TReturn> getter)
        {
            return getter(builder());
        }
    }
}