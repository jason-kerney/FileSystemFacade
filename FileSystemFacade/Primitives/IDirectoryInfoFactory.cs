namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// A factory for building IDirectoryInfo objects
    /// </summary>
    public interface IDirectoryInfoFactory
    {
        /// <summary>
        /// Creates a new instance of the IDirectoryInfo interface on the specified path.
        /// </summary>
        /// <param name="path">A string specifying the path on which to create the IDirectoryInfo.</param>
        /// <returns>A new instance of the IDirectoryInfo interface on the specified path.</returns>
        IDirectoryInfo GetDirectoryInfo(string path);
    }

    internal class DirectoryInfoFactory : IDirectoryInfoFactory
    {
        public IDirectoryInfo GetDirectoryInfo(string path)
        {
            return new DirectoryInfo(path);
        }
    }
}