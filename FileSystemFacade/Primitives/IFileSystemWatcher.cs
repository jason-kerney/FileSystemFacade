using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// Listens to the file system change notifications and raises events when a directory, or file in a directory, changes.
    /// </summary>
    public interface IFileSystemWatcher : ISupportInitialize, IDisposable, IComponent
    {
        /// <summary>
        /// Gets the IContainer that contains the Component.
        /// </summary>
        [Browsable(false)] IContainer? Container { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the component is enabled.
        /// </summary>
        bool EnableRaisingEvents { get; set; }
        /// <summary>
        /// Gets or sets the filter string used to determine what files are monitored in a directory.
        /// </summary>
        string Filter { get; set; }
        /// <summary>
        /// Gets the collection of all the filters used to determine what files are monitored in a directory.
        /// </summary>
        Collection<string> Filters { get; }
        /// <summary>
        /// Gets or sets a value indicating whether subdirectories within the specified path should be monitored.
        /// </summary>
        bool IncludeSubdirectories { get; set; }
        /// <summary>
        /// Gets or sets the size (in bytes) of the internal buffer.
        /// </summary>
        int InternalBufferSize { get; set; }
        /// <summary>
        /// Gets or sets the type of changes to watch for.
        /// </summary>
        System.IO.NotifyFilters NotifyFilter { get; set; }
        /// <summary>
        /// Gets or sets the path of the directory to watch.
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Gets or sets the object used to marshal the event handler calls issued as a result of a directory change.
        /// </summary>
        ISynchronizeInvoke? SynchronizingObject { get; set; }
        /// <summary>
        /// Occurs when a file or directory in the specified Path is changed.
        /// </summary>
        event System.IO.FileSystemEventHandler? Changed;
        /// <summary>
        /// Occurs when a file or directory in the specified Path is created.
        /// </summary>
        event System.IO.FileSystemEventHandler? Created;
        /// <summary>
        /// Occurs when a file or directory in the specified Path is deleted.
        /// </summary>
        event System.IO.FileSystemEventHandler? Deleted;
        /// <summary>
        /// Occurs when the instance of FileSystemWatcher is unable to continue monitoring changes or when the internal buffer overflows.
        /// </summary>
        event System.IO.ErrorEventHandler? Error;
        /// <summary>
        /// Occurs when a file or directory in the specified Path is renamed.
        /// </summary>
        event System.IO.RenamedEventHandler? Renamed;
        /// <summary>
        /// A synchronous method that returns a structure that contains specific information on the change that occurred, given the type of change you want to monitor.
        /// </summary>
        /// <param name="changeType">The WatcherChangeTypes to watch for.</param>
        /// <returns>A WaitForChangedResult that contains specific information on the change that occurred.</returns>
        IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType);
        /// <summary>
        /// A synchronous method that returns a structure that contains specific information on the change that occurred, given the type of change you want to monitor and the time (in milliseconds) to wait before timing out.
        /// </summary>
        /// <param name="changeType">The WatcherChangeTypes to watch for.</param>
        /// <param name="timeout">The time (in milliseconds) to wait before timing out.</param>
        /// <returns>A WaitForChangedResult that contains specific information on the change that occurred.</returns>
        IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType, int timeout);
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

        /// <summary>
        /// Gets the IContainer that contains the Component.
        /// </summary>
        public IContainer? Container => watcher.Container;

        /// <summary>
        /// Gets or sets a value indicating whether the component is enabled.
        /// </summary>
        public bool EnableRaisingEvents
        {
            get => watcher.EnableRaisingEvents;
            set => watcher.EnableRaisingEvents = value;
        }

        /// <summary>
        /// Gets or sets the filter string used to determine what files are monitored in a directory.
        /// </summary>
        public string Filter
        {
            get => watcher.Filter;
            set => watcher.Filter = value;
        }

        /// <summary>
        /// Gets the collection of all the filters used to determine what files are monitored in a directory.
        /// </summary>
        public Collection<string> Filters => watcher.Filters;

        /// <summary>
        /// Gets or sets a value indicating whether subdirectories within the specified path should be monitored.
        /// </summary>
        public bool IncludeSubdirectories
        {
            get => watcher.IncludeSubdirectories;
            set => watcher.IncludeSubdirectories = value;
        }

        /// <summary>
        /// Gets or sets the size (in bytes) of the internal buffer.
        /// </summary>
        public int InternalBufferSize
        {
            get => watcher.InternalBufferSize;
            set => watcher.InternalBufferSize = value;
        }

        /// <summary>
        /// Gets or sets the type of changes to watch for.
        /// </summary>
        public System.IO.NotifyFilters NotifyFilter
        {
            get => watcher.NotifyFilter;
            set => watcher.NotifyFilter = value;
        }

        /// <summary>
        /// Gets or sets the path of the directory to watch.
        /// </summary>
        public string Path
        {
            get => watcher.Path;
            set => watcher.Path = value;
        }

        /// <summary>
        /// Gets or sets the object used to marshal the event handler calls issued as a result of a directory change.
        /// </summary>
        public ISynchronizeInvoke? SynchronizingObject
        {
            get => watcher.SynchronizingObject;
            set => watcher.SynchronizingObject = value;
        }

        /// <summary>
        /// Occurs when a file or directory in the specified Path is changed.
        /// </summary>
        public event System.IO.FileSystemEventHandler? Changed;

        protected virtual void OnChanged(System.IO.FileSystemEventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when a file or directory in the specified Path is created.
        /// </summary>
        public event System.IO.FileSystemEventHandler? Created;

        protected virtual void OnCreated(System.IO.FileSystemEventArgs e)
        {
            Created?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when a file or directory in the specified Path is deleted.
        /// </summary>
        public event System.IO.FileSystemEventHandler? Deleted;

        protected virtual void OnDeleted(System.IO.FileSystemEventArgs e)
        {
            Deleted?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when the instance of FileSystemWatcher is unable to continue monitoring changes or when the internal buffer overflows.
        /// </summary>
        public event System.IO.ErrorEventHandler? Error;

        protected virtual void OnError(System.IO.ErrorEventArgs e)
        {
            Error?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when a file or directory in the specified Path is renamed.
        /// </summary>
        public event System.IO.RenamedEventHandler? Renamed;

        protected virtual void OnRenamed(System.IO.RenamedEventArgs e)
        {
            Renamed?.Invoke(this, e);
        }

        /// <summary>
        /// A synchronous method that returns a structure that contains specific information on the change that occurred, given the type of change you want to monitor.
        /// </summary>
        /// <param name="changeType">The WatcherChangeTypes to watch for.</param>
        /// <returns>A WaitForChangedResult that contains specific information on the change that occurred.</returns>
        public IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType)
        {
            return new WaitForChangedResult(watcher.WaitForChanged(changeType));
        }

        /// <summary>
        /// A synchronous method that returns a structure that contains specific information on the change that occurred, given the type of change you want to monitor and the time (in milliseconds) to wait before timing out.
        /// </summary>
        /// <param name="changeType">The WatcherChangeTypes to watch for.</param>
        /// <param name="timeout">The time (in milliseconds) to wait before timing out.</param>
        /// <returns>A WaitForChangedResult that contains specific information on the change that occurred.</returns>
        public IWaitForChangedResult WaitForChanged(System.IO.WatcherChangeTypes changeType, int timeout)
        {
            return new WaitForChangedResult(watcher.WaitForChanged(changeType, timeout));
        }
    }
}