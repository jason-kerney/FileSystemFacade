namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// A factory to build IDriveInfos
    /// </summary>
    public interface IDriveInfoFactory
    {
        /// <summary>
        /// Provides access to information on the specified drive.
        /// </summary>
        /// <param name="driveName">A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.</param>
        /// <returns>Information on the specified drive.</returns>
        IDriveInfo DriveInfo(string driveName);
    }

    internal class DriveInfoFactory : IDriveInfoFactory
    {
        public IDriveInfo DriveInfo(string driveName)
        {
            return new DriveInfo(driveName);
        }
    }
}