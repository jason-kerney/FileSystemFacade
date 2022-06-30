using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    /// <summary>
    /// A builder used to aid in replacing drive items in the static file system. This object makes testing easier.
    /// </summary>
    public interface IStaticDriveReplacementBuilder
    {
        /// <summary>
        /// Configures the IDriveInfoFactory to use when the static file system is put into replacement mode.
        /// </summary>
        /// <param name="factory">The IDriveInfoFactory to use.</param>
        /// <returns>An instance of the builder with IDriveInfoFactory configured to be replaced.</returns>
        IStaticDriveReplacementBuilder ReplaceDriveInfo(IDriveInfoFactory factory);
        /// <summary>
        /// Configures the IDrives to use when the static file system is put into replacement mode.
        /// </summary>
        /// <param name="drives">The IDrives to use when the static file system is put into replacement mode.</param>
        /// <returns>An instance of the builder with the IDrives configured to be replaced.</returns>
        IStaticDriveReplacementBuilder ReplaceDrives(IDrives drives);
        /// <summary>
        /// Builds the configuration item that is used to tell the static file system what drive based objects to use when put into replacement mode.
        /// </summary>
        /// <returns>The configuration item that is used to tell the static file system what drive based objects to use when put into replacement mode.</returns>
        IStaticDriveReplacement Build();
    }
    
    
    internal class StaticDriveReplacementBuilder: IStaticDriveReplacementBuilder
    {
        public StaticDriveReplacementBuilder(IDriveInfoFactory driveInfo, IDrives drives)
        {
            DriveInfo = driveInfo;
            Drives = drives;
        }

        private IDriveInfoFactory DriveInfo { get; set; }
        private IDrives Drives { get; set; }
        
        public IStaticDriveReplacementBuilder ReplaceDriveInfo(IDriveInfoFactory factory)
        {
            DriveInfo = factory;
            return this;
        }

        public IStaticDriveReplacementBuilder ReplaceDrives(IDrives drives)
        {
            Drives = drives;
            return this;
        }

        public IStaticDriveReplacement Build()
        {
            return new StaticDriveReplacement(DriveInfo, Drives);
        }
    }
}