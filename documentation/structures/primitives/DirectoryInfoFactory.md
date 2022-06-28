<!--bl
(filemeta
    (title "Directory Info Factory"))
/bl-->

###Summary

A factory for building IDirectoryInfo objects

```csharp
public interface IDirectoryInfoFactory
```

###IDirectoryInfoFactory

- [12.1 Get Directory Info](#user-content-idirectoryinfofactorygetdirectoryinfo)

###IDirectoryInfoFactory.GetDirectoryInfo

```csharp
IDirectoryInfo GetDirectoryInfo(string path);
```

Creates a new instance of the IDirectoryInfo interface on the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string specifying the path on which to create the IDirectoryInfo.

**returns** [IDirectoryInfo](#user-content-directory-info)

A new instance of the IDirectoryInfo interface on the specified path.