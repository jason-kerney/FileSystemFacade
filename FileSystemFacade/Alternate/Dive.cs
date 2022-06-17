using System;
using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    public static class Dive
    {
        public static IDisposable Replace(IStaticDriveReplacement replacement)
        {
            var original = new StaticDriveReplacement(DriveInfo, Obj);

            DriveInfo = replacement.DriveInfo;
            Obj = replacement.Drives;

            return new DisposableAction(() =>
            {
                DriveInfo = original.DriveInfo;
                Obj = original.Drives;
            });
        }
        
        public static IDriveInfoBuilder DriveInfo { get; private set; }
        private static IDrives Obj { get; set; }

        public static IDriveInfo[] GetDrives() => Obj.GetDrives();
    }
}