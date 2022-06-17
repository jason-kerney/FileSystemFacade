using System;

namespace FileSystemFacade
{
    internal class DisposableAction : IDisposable
    {
        private readonly Action action;
        private bool disposed;

        public DisposableAction(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            if (disposed) return;

            action();
            disposed = true;
        }
    }
}