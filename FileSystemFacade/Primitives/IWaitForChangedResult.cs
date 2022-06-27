namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// Contains information on the change that occurred.
    /// </summary>
    public interface IWaitForChangedResult
    {
        /// <summary>
        /// Gets or sets the type of change that occurred.
        /// </summary>
        System.IO.WatcherChangeTypes ChangeType { get; set; }
        /// <summary>
        /// Gets or sets the name of the file or directory that changed.
        /// </summary>
        string? Name { get; set; }
        /// <summary>
        /// Gets or sets the original name of the file or directory that was renamed.
        /// </summary>
        string? OldName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the wait operation timed out.
        /// </summary>
        bool TimedOut { get; set; }
    }

    internal struct WaitForChangedResult : IWaitForChangedResult
    {
        private System.IO.WaitForChangedResult result;

        public WaitForChangedResult(System.IO.WaitForChangedResult result)
        {
            this.result = result;
        }

        /// <summary>
        /// Gets or sets the type of change that occurred.
        /// </summary>
        public System.IO.WatcherChangeTypes ChangeType
        {
            get => result.ChangeType;
            set => result.ChangeType = value;
        }

        /// <summary>
        /// Gets or sets the name of the file or directory that changed.
        /// </summary>
        public string Name
        {
            get => result.Name;
            set => result.Name = value;
        }

        /// <summary>
        /// Gets or sets the original name of the file or directory that was renamed.
        /// </summary>
        public string OldName
        {
            get => result.OldName;
            set => result.OldName = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the wait operation timed out.
        /// </summary>
        public bool TimedOut
        {
            get => result.TimedOut;
            set => result.TimedOut = value;
        }
    }
}