using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    /// <summary>
    /// The items to use in replacing drive objects in the static file system. This class makes testing easier.
    /// </summary>
    public interface IStaticDriveReplacement
    {
        /// <summary>
        /// Gets the IDriveInfoFactory to use when the static file system is set to replacement mode.
        /// </summary>
        IDriveInfoFactory DriveInfo { get; }
        /// <summary>
        /// The IDrives to use when the static file system is set to replacement mode.
        /// </summary>
        IDrives Drives { get; }
    }

    internal class StaticDriveReplacement : IStaticDriveReplacement
    {
        public StaticDriveReplacement(IDriveInfoFactory driveInfo, IDrives drives)
        {
            DriveInfo = driveInfo;
            Drives = drives;
        }

        public IDriveInfoFactory DriveInfo { get; }
        public IDrives Drives { get; }
    }
}