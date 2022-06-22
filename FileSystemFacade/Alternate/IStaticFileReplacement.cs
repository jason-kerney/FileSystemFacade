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
    
    /// <summary>
    /// A builder for aiding in the creation of an IStaticFIleReplacement. This class simplifies testing.
    /// </summary>
    public interface IStaticFileReplacementBuilder
    {
        /// <summary>
        /// Allows for the replacement of the IFileStreamFactory in the static FileSystem Objects.
        /// </summary>
        /// <param name="newFileStream">The IFileStreamFactory to use instead of the default one.</param>
        /// <returns>Returns an instance of the builder with the IFileStreamFactory set up to be replaced.</returns>
        IStaticFileReplacementBuilder ReplaceFileStream(IFileStreamFactory newFileStream);
        /// <summary>
        /// Allows for the replacement of the IFileInfoFactory in the static file system Objects.
        /// </summary>
        /// <param name="newFileInfo">The IFileInfoFactory to use instead of the default one.</param>
        /// <returns>Returns an instance of the builder with the IFileInfoFactory set up to be replaced.</returns>
        IStaticFileReplacementBuilder ReplaceFileInfo(IFileInfoFactory newFileInfo);
        /// <summary>
        /// Allows for the replacement of the IFile in the static file system Objects.
        /// </summary>
        /// <param name="newFile">The IFile to use instead of the default one.</param>
        /// <returns>Returns an instance of the builder with the IFile set up to be replaced.</returns>
        IStaticFileReplacementBuilder ReplaceFile(IFile newFile);
        /// <summary>
        /// Builds the replacement configuration used by the Static File System objects with the configured items for replacement.
        /// </summary>
        /// <returns>An instance of the configuration used to do replacement in the static file system objects.</returns>
        IStaticFileReplacement Build();
    }

    internal class StaticFileReplacementBuilder: IStaticFileReplacementBuilder
    {
        public StaticFileReplacementBuilder(IFileStreamFactory fileStream, IFileInfoFactory fileInfo, IFile file)
        {
            FileStream = fileStream;
            FileInfo = fileInfo;
            File = file;
        }

        private IFileStreamFactory FileStream { get; set; }
        private IFileInfoFactory FileInfo { get; set; }
        private IFile File { get; set; }
        
        public IStaticFileReplacementBuilder ReplaceFileStream(IFileStreamFactory newFileStream)
        {
            FileStream = newFileStream;
            return this;
        }

        public IStaticFileReplacementBuilder ReplaceFileInfo(IFileInfoFactory newFileInfo)
        {
            FileInfo = newFileInfo;
            return this;
        }

        public IStaticFileReplacementBuilder ReplaceFile(IFile newFile)
        {
            File = newFile;
            return this;
        }

        public IStaticFileReplacement Build()
        {
            return new StaticFileReplacement(FileStream, FileInfo, File);
        }
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