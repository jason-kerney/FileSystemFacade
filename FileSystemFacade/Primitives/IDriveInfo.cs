namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// This interface models a drive and provides methods and properties to query for drive information. Use IDrives to determine what drives are available; and use IDriveInfo to determine what type of drive it is. You can also query to determine the capacity and available free space on the drive.
    /// </summary>
    public interface IDriveInfo
    {
        /// <summary>
        /// Indicates the amount of available free space on a drive, in bytes.
        /// </summary>
        long AvailableFreeSpace { get; }
        /// <summary>
        /// Gets the name of the file system, such as NTFS or FAT32.
        /// </summary>
        string DriveFormat { get; }
        /// <summary>
        /// Gets the drive type, such as CD-ROM, removable, network, or fixed.
        /// </summary>
        System.IO.DriveType DriveType { get; }
        /// <summary>
        /// Gets a value that indicates whether a drive is ready.
        /// </summary>
        bool IsReady { get; }
        /// <summary>
        /// Gets the name of a drive, such as C:\.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the root directory of a drive.
        /// </summary>
        IDirectoryInfo RootDirectory { get; }
        /// <summary>
        /// Gets the total amount of free space available on a drive, in bytes.
        /// </summary>
        long TotalFreeSpace { get; }
        /// <summary>
        /// Gets the total size of storage space on a drive, in bytes.
        /// </summary>
        long TotalSize { get; }
        /// <summary>
        /// Gets or sets the volume label of a drive.
        /// </summary>
        string VolumeLabel { get; [System.Runtime.Versioning.SupportedOSPlatform("windows")] set; }        
    }

    internal class DriveInfo : IDriveInfo
    {
        private readonly System.IO.DriveInfo driveInfo;

        internal DriveInfo(System.IO.DriveInfo driveInfo)
        {
            this.driveInfo = driveInfo;
        }

        internal DriveInfo(string driveName) : this(new System.IO.DriveInfo(driveName)) { }

        public long AvailableFreeSpace => driveInfo.AvailableFreeSpace;
        public string DriveFormat => driveInfo.DriveFormat;
        public System.IO.DriveType DriveType => driveInfo.DriveType;
        public bool IsReady => driveInfo.IsReady;
        public string Name => driveInfo.Name;
        public IDirectoryInfo RootDirectory => new DirectoryInfo(driveInfo.RootDirectory);
        public long TotalFreeSpace => driveInfo.TotalFreeSpace;
        public long TotalSize => driveInfo.TotalSize;
        
        public string VolumeLabel
        {
            get => driveInfo.VolumeLabel;
            [System.Runtime.Versioning.SupportedOSPlatform("windows")]
            set => driveInfo.VolumeLabel = value;
        }
    }
}