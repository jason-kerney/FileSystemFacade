using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    /// <summary>
    /// This allows for file based objects to be replaced in the static file system objects. This interface simplifies testing.
    /// </summary>
    public interface IStaticFileReplacement
    {
        /// <summary>
        /// The IFileStreamFactory to use when the static file system is put into replacement mode.
        /// </summary>
        IFileStreamFactory FileStream { get; }
        /// <summary>
        /// The IFileInfoFactory to use when the static file system is put into replacement mode.
        /// </summary>
        IFileInfoFactory FileInfo { get; }
        /// <summary>
        /// The IFile to use when the static file system is put into replacement mode.
        /// </summary>
        IFile File { get; }
    }

    internal class StaticFileReplacement: IStaticFileReplacement 
    {
        internal StaticFileReplacement(IFileStreamFactory fileStream, IFileInfoFactory fileInfo, IFile file)
        {
            FileStream = fileStream;
            FileInfo = fileInfo;
            File = file;
        }

        public IFileStreamFactory FileStream { get; }
        public IFileInfoFactory FileInfo { get; }
        public IFile File { get; }
    }
}