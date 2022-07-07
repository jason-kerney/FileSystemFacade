<!--bl
(filemeta
    (title "Static File Replacement Builder"))
/bl-->

### Summary

A builder for aiding in the creation of an IStaticFIleReplacement. This class simplifies testing.

```csharp
public interface IStaticFileReplacementBuilder
```

### IStaticFileReplacementBuilder

- [9.1 Replace File Stream](#user-content-istaticfilereplacementbuilderreplacefilestream)
- [9.2 Replace File Info](#user-content-istaticfilereplacementbuilderreplacefileinfo)
- [9.3 Replace File](#user-content-istaticfilereplacementbuilderreplacefile)
- [9.4 Build](#user-content-istaticfilereplacementbuilderbuild)

<!--
#user-content-istaticfilereplacementbuilder
-->

### IStaticFileReplacementBuilder.ReplaceFileStream

```csharp
IStaticFileReplacementBuilder ReplaceFileStream(IFileStreamFactory newFileStream);
```

Allows for the replacement of the IFileStreamFactory in the static FileSystem Objects.

**newFileStream** [IFileStreamFactory](./documentation/structures/primitives/FileStreamFactory.md#file-stream-factory)

The IFileStreamFactory to use instead of the default one.

**returns** [IStaticFileReplacementBuilder](#user-content-istaticfilereplacementbuilder)

Returns an instance of the builder with the IFileStreamFactory set up to be replaced.

### IStaticFileReplacementBuilder.ReplaceFileInfo

```csharp
IStaticFileReplacementBuilder ReplaceFileInfo(IFileInfoFactory newFileInfo);
```

Allows for the replacement of the IFileInfoFactory in the static file system Objects.

**newFileInfo** [IFileInfoFactory](./documentation/structures/primitives/FileInfoFactory.md#file-info-factory)

The IFileInfoFactory to use instead of the default one.

**returns** [IStaticFileReplacementBuilder](#user-content-istaticfilereplacementbuilder)

Returns an instance of the builder with the IFileInfoFactory set up to be replaced.

### IStaticFileReplacementBuilder.ReplaceFile

```csharp
IStaticFileReplacementBuilder ReplaceFile(IFile newFile);
```

Allows for the replacement of the IFile in the static file system Objects.

**newFile** [IFile](./documentation/structures/primitives/File.md#file)

The IFile to use instead of the default one.

**returns** [IStaticFileReplacementBuilder](#user-content-istaticfilereplacementbuilder)

Returns an instance of the builder with the IFile set up to be replaced.

### IStaticFileReplacementBuilder.

```csharp
IStaticFileReplacement Build();
```

Builds the replacement configuration used by the Static File System objects with the configured items for replacement.

**returns** [IStaticFileReplacement](#user-content-static-file-replacement)

An instance of the configuration used to do replacement in the static file system objects.