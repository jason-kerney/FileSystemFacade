using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FileSystemFacade.Primitives
{
    public interface IWaitForChangedResult
    {
        System.IO.WatcherChangeTypes ChangeType { get; set; }
        string? Name { get; set; }
        string? OldName { get; set; }
        bool TimedOut { get; set; }
    }

    internal struct WaitForChangedResult : IWaitForChangedResult
    {
        private System.IO.WaitForChangedResult result;

        public WaitForChangedResult(System.IO.WaitForChangedResult result)
        {
            this.result = result;
        }

        public System.IO.WatcherChangeTypes ChangeType
        {
            get => result.ChangeType;
            set => result.ChangeType = value;
        }

        public string Name
        {
            get => result.Name;
            set => result.Name = value;
        }

        public string OldName
        {
            get => result.OldName;
            set => result.OldName = value;
        }

        public bool TimedOut
        {
            get => result.TimedOut;
            set => result.TimedOut = value;
        }
    }

    public interface IFileSystemWatcher : ISupportInitialize, IDisposable, IComponent
    {
        [Browsable(false)] IContainer? Container { get; }
        bool EnableRaisingEvents { get; set; }
        string Filter { get; set; }
        Collection<string> Filters { get; }
        bool IncludeSubdirectories { get; set; }
        int InternalBufferSize { get; set; }
        System.IO.NotifyFilters NotifyFilter { get; set; }
        string Path { get; set; }
        ISynchronizeInvoke? SynchronizingObject { get; set; }
        event System.IO.FileSystemEventHandler? Changed;
        event System.IO.FileSystemEventHandler? Created;
        event System.IO.FileSystemEventHandler? Deleted;
        event System.IO.ErrorEventHandler? Error;
        event System.IO.RenamedEventHandler? Renamed;
        IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType);
        IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType, int timeout);
    }

    public interface IFilesSystemWatcherBuilder
    {
        IFileSystemWatcher GetFileSystemWatcher();
        IFileSystemWatcher GetFileSystemWatcher(string path);
        IFileSystemWatcher GetFileSystemWatcher(string path, string filter);
    }

    internal class FilesSystemWatcherBuilder : IFilesSystemWatcherBuilder
    {
        public IFileSystemWatcher GetFileSystemWatcher() => new FileSystemWatcher();

        public IFileSystemWatcher GetFileSystemWatcher(string path) => new FileSystemWatcher(path);

        public IFileSystemWatcher GetFileSystemWatcher(string path, string filter) => new FileSystemWatcher(path, filter);
    }
    
    internal class FileSystemWatcher : MarshalByRefObject, IFileSystemWatcher
    {
        private System.IO.FileSystemWatcher watcher;
        private bool disposed;

        ~FileSystemWatcher()
        {
            Dispose();
        }

        internal FileSystemWatcher() : this(new System.IO.FileSystemWatcher())
        {
        }

        internal FileSystemWatcher(string path) : this(new System.IO.FileSystemWatcher(path))
        {
        }

        internal FileSystemWatcher(string path, string filter) : this(new System.IO.FileSystemWatcher(path, filter))
        {
        }

        internal FileSystemWatcher(System.IO.FileSystemWatcher watcher)
        {
            this.watcher = watcher;
            this.watcher.Changed += (_, e) => OnChanged(e);
            this.watcher.Created += (_, e) => OnCreated(e);
            this.watcher.Deleted += (_, e) => OnDeleted(e);
            this.watcher.Error += (_, e) => OnError(e);
            this.watcher.Renamed += (_, e) => OnRenamed(e);
            this.watcher.Disposed += (_, e) => OnDisposed(e);
        }

        public void BeginInit()
        {
            watcher.BeginInit();
        }

        public void EndInit()
        {
            watcher.EndInit();
        }

        public void Dispose()
        {
            if (disposed) return;

            watcher.Dispose();
            watcher = null;
            disposed = true;
            GC.SuppressFinalize(this);
        }

        public ISite Site
        {
            get => watcher.Site;
            set => watcher.Site = value;
        }

        public event EventHandler? Disposed;

        protected virtual void OnDisposed(EventArgs e)
        {
            Disposed?.Invoke(this, e);
        }

        public IContainer? Container => watcher.Container;

        public bool EnableRaisingEvents
        {
            get => watcher.EnableRaisingEvents;
            set => watcher.EnableRaisingEvents = value;
        }

        public string Filter
        {
            get => watcher.Filter;
            set => watcher.Filter = value;
        }

        public Collection<string> Filters => watcher.Filters;

        public bool IncludeSubdirectories
        {
            get => watcher.IncludeSubdirectories;
            set => watcher.IncludeSubdirectories = value;
        }

        public int InternalBufferSize
        {
            get => watcher.InternalBufferSize;
            set => watcher.InternalBufferSize = value;
        }

        public System.IO.NotifyFilters NotifyFilter
        {
            get => watcher.NotifyFilter;
            set => watcher.NotifyFilter = value;
        }

        public string Path
        {
            get => watcher.Path;
            set => watcher.Path = value;
        }

        public ISynchronizeInvoke? SynchronizingObject
        {
            get => watcher.SynchronizingObject;
            set => watcher.SynchronizingObject = value;
        }

        public event System.IO.FileSystemEventHandler? Changed;

        protected virtual void OnChanged(System.IO.FileSystemEventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public event System.IO.FileSystemEventHandler? Created;

        protected virtual void OnCreated(System.IO.FileSystemEventArgs e)
        {
            Created?.Invoke(this, e);
        }

        public event System.IO.FileSystemEventHandler? Deleted;

        protected virtual void OnDeleted(System.IO.FileSystemEventArgs e)
        {
            Deleted?.Invoke(this, e);
        }

        public event System.IO.ErrorEventHandler? Error;

        protected virtual void OnError(System.IO.ErrorEventArgs e)
        {
            Error?.Invoke(this, e);
        }

        public event System.IO.RenamedEventHandler? Renamed;

        protected virtual void OnRenamed(System.IO.RenamedEventArgs e)
        {
            Renamed?.Invoke(this, e);
        }

        public IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType)
        {
            return new WaitForChangedResult(watcher.WaitForChanged(changeType));
        }

        public IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType, int timeout)
        {
            return new WaitForChangedResult(watcher.WaitForChanged(changeType, timeout));
        }
    }
}