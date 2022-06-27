using System.Linq;

namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// Use IDrives to determine what drives are available, and what type of drives they are. 
    /// </summary>
    public interface IDrives
    {
        /// <summary>
        /// Retrieves the drive names of all logical drives on a computer.
        /// </summary>
        /// <returns>An array of type IDriveInfo that represents the logical drives on a computer.</returns>
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