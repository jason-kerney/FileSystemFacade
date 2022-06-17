using System.IO;
using System.Linq;

namespace FileSystemFacade.Primitives
{
    public interface IDriveInfo
    {
        long AvailableFreeSpace { get; }
        string DriveFormat { get; }
        System.IO.DriveType DriveType { get; }
        bool IsReady { get; }
        string Name { get; }
        IDirectoryInfo RootDirectory { get; }
        long TotalFreeSpace { get; }
        long TotalSize { get; }
        string VolumeLabel { get; [System.Runtime.Versioning.SupportedOSPlatform("windows")] set; }
        
    }

    public interface IDriveInfoBuilder
    {
        IDriveInfo DriveInfo(string driveName);
    }

    internal class DriveInfoBuilder : IDriveInfoBuilder
    {
        public IDriveInfo DriveInfo(string driveName)
        {
            return new DriveInfo(driveName);
        }
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
        public DriveType DriveType => driveInfo.DriveType;
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

    public interface IDrives
    {
        IDriveInfo[] GetDrives ();
    }

    internal class Drives : IDrives
    {
        public IDriveInfo[] GetDrives()
        {
            return (
                from drive in System.IO.DriveInfo.GetDrives()
                select (IDriveInfo)new DriveInfo(drive)
            ).ToArray();
        }
    }
}