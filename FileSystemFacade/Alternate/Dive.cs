using System;
using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    /// <summary>
    /// A static class that aids in getting Drive info and an enumeration of drives on the system.
    /// It is preferable to use the Atomic File System. This should only be used when you are creating long file items that live longer then a single method.
    /// </summary>
    public static class Dive
    {
        /// <summary>
        /// Puts the static Drive class in replacement mode. This temporarily causes the static Drive class to replace how it works.
        /// This is used to allow testing.
        /// WARNING: This allows changing of how the system works until the returned object is disposed.
        /// </summary>
        /// <param name="replacement">The configuration of how to replace the inners of the static class.</param>
        /// <returns>
        /// An IDisposable that when disposed reverts the static Drive class to its default behavior
        /// WARNING: This allows changing of how the system works until the returned object is disposed.
        /// </returns>
        public static IDisposable ReplaceStaticDriveSubSystem(IStaticDriveReplacement replacement)
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
        
        /// <summary>
        /// This returns an IDriveInfoFactory used to build information about a Drive on the system.
        /// </summary>
        public static IDriveInfoFactory DriveInfo { get; private set; }
        private static IDrives Obj { get; set; }

        /// <summary>
        /// Retrieves the drive names of all logical drives on a computer.
        /// </summary>
        /// <returns>An array of type IDriveInfo that represents the logical drives on a computer.</returns>
        public static IDriveInfo[] GetDrives() => Obj.GetDrives();

        /// <summary>
        /// Returns a new builder object that makes configuring how the static Drive class behaves in replacement mode easier.
        /// This method facilitates testing.
        /// </summary>
        /// <returns>A builder to build the configuration object used by the 'Replace' method.</returns>
        public static IStaticDriveReplacementBuilder BuildReplacement()
        {
            return new StaticDriveReplacementBuilder(DriveInfo, Obj);
        }
    }
}