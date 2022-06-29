# File Info Factory

## Summary

A factory to build IFileInfo Objects

```csharp
public interface IFileInfoFactory
```

## IFileInfoFactory

-[11.1 Get File Info](#user-content-ifileinfofactorygetfileinfo)

## IFileInfoFactory.GetFileInfo

```csharp
IFileInfo GetFileInfo(string fileName);
```

Creates a new instance of the FileInfo class, which acts as a wrapper for a file path.

**fileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.

**returns** [IFileInfo](./FileInfo.md)

A new instance of the FileInfo class, which acts as a wrapper for a file path.