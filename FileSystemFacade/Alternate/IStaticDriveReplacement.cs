using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    public interface IStaticDriveReplacement
    {
        IDriveInfoBuilder DriveInfo { get; }
        IDrives Drives { get; }
    }

    public interface IStaticDriveReplacementBuilder
    {
        IStaticDriveReplacementBuilder ReplaceDriveInfo(IDriveInfoBuilder builder);
        IStaticDriveReplacementBuilder ReplaceDrives(IDrives drives);

        IStaticDriveReplacement Build();
    }

    internal class StaticDriveReplacement : IStaticDriveReplacement
    {
        public StaticDriveReplacement(IDriveInfoBuilder driveInfo, IDrives drives)
        {
            DriveInfo = driveInfo;
            Drives = drives;
        }

        public IDriveInfoBuilder DriveInfo { get; }
        public IDrives Drives { get; }
    }

    internal class StaticDriveReplacementBuilder: IStaticDriveReplacementBuilder
    {
        public StaticDriveReplacementBuilder(IDriveInfoBuilder driveInfo, IDrives drives)
        {
            DriveInfo = driveInfo;
            Drives = drives;
        }

        private IDriveInfoBuilder DriveInfo { get; set; }
        private IDrives Drives { get; set; }
        
        public IStaticDriveReplacementBuilder ReplaceDriveInfo(IDriveInfoBuilder builder)
        {
            DriveInfo = builder;
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