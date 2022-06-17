using FileSystemFacade.Primitives;

namespace FileSystemFacade.Alternate
{
    public interface IStaticFileReplacement
    {
        IFileStreamBuilder FileStream { get; }
        IFileInfoBuilder FileInfo { get; }
        IFile File { get; }
    }
    
    public interface IStaticFileReplacementBuilder
    {
        IStaticFileReplacementBuilder ReplaceFileStream(IFileStreamBuilder newFileStream);
        IStaticFileReplacementBuilder ReplaceFileInfo(IFileInfoBuilder newFileInfo);
        IStaticFileReplacementBuilder ReplaceFile(IFile newFile);
        IStaticFileReplacement Build();
    }

    internal class StaticFileReplacementBuilder: IStaticFileReplacementBuilder
    {
        public StaticFileReplacementBuilder(IFileStreamBuilder fileStream, IFileInfoBuilder fileInfo, IFile file)
        {
            FileStream = fileStream;
            FileInfo = fileInfo;
            File = file;
        }

        private IFileStreamBuilder FileStream { get; set; }
        private IFileInfoBuilder FileInfo { get; set; }
        private IFile File { get; set; }
        
        public IStaticFileReplacementBuilder ReplaceFileStream(IFileStreamBuilder newFileStream)
        {
            FileStream = newFileStream;
            return this;
        }

        public IStaticFileReplacementBuilder ReplaceFileInfo(IFileInfoBuilder newFileInfo)
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
        internal StaticFileReplacement(IFileStreamBuilder fileStream, IFileInfoBuilder fileInfo, IFile file)
        {
            FileStream = fileStream;
            FileInfo = fileInfo;
            File = file;
        }

        public IFileStreamBuilder FileStream { get; }
        public IFileInfoBuilder FileInfo { get; }
        public IFile File { get; }
    }
}