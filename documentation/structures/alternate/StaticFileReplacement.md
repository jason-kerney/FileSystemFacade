<!--bl
(filemeta
    (title "Static File Replacement"))
/bl-->

### Summary

This allows for file based objects to be replaced in the static file system objects. This interface simplifies testing.

```csharp
public interface IStaticFileReplacement
```

### IStaticFileReplacement

- [10.1 File Stream](#user-content-istaticfilereplacementfilestream)
- [10.2 File Info](#user-content-istaticfilereplacementfileinfo)
- [10.2 File](#user-content-istaticfilereplacementfile)

<!--
#user-content-istaticfilereplacement
-->

### IStaticFileReplacement.FileStream

```csharp
IFileStreamFactory FileStream { get; }
```

The IFileStreamFactory to use when the static file system is put into replacement mode.

**returns** [IFileStreamFactory](./documentation/structures/primitives/FileStreamFactory.md#file-stream-factory)

The IFileStreamFactory to use when the static file system is put into replacement mode.

### IStaticFileReplacement.FileInfo

```csharp
IFileInfoFactory FileInfo { get; }
```

The IFileInfoFactory to use when the static file system is put into replacement mode.

**returns** [IFileInfoFactory](./documentation/structures/primitives/FileInfoFactory.md#file-info-factory)

The IFileInfoFactory to use when the static file system is put into replacement mode.

### IStaticFileReplacement.File

```csharp
IFile File { get; }
```

The IFile to use when the static file system is put into replacement mode.

**returns** [IFile](./documentation/structures/primitives/File.md#file)

The IFile to use when the static file system is put into replacement mode.