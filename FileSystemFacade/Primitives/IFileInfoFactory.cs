namespace FileSystemFacade.Primitives
{
    /// <summary>
    /// A factory to build IFileInfo Objects
    /// </summary>
    public interface IFileInfoFactory
    {
        /// <summary>
        /// Creates a new instance of the FileInfo class, which acts as a wrapper for a file path.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.</param>
        /// <returns>A new instance of the FileInfo class, which acts as a wrapper for a file path.</returns>
        IFileInfo GetFileInfo(string fileName);
    }

    internal class FileInfoFactory : IFileInfoFactory
    {
        public IFileInfo GetFileInfo(string fileName)
        {
            return new FileInfo(fileName);
        }
    }
}