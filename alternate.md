
<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
# File System Facade's Alternate File System Access #
#### A guide to the interfaces and objects that allow you to access the file system from a static class. ####

## Table Of Contents ##

- [Section 1: Description](#user-content-description)
- [Section 2: Drive](#user-content-drive)
- [Section 3: Static Drive Replacement Builder](#user-content-static-drive-replacement-builder)
- [Section 4: Static Drive Replacement](#user-content-static-drive-replacement)
- [Section 5: Directory](#user-content-directory)
- [Section 6: Static Directory Replacement Builder](#user-content-static-directory-replacement-builder)
- [Section 7: Static Directory Replacement](#user-content-static-directory-replacement)
- [Section 8: File](#user-content-file)
- [Section 9: Static File Replacement Builder](#user-content-static-file-replacement-builder)
- [Section 10: Static File Replacement](#user-content-static-file-replacement)
- [Section 11: Primitives](#user-content-primitives)

## Description ##

The main way to access file system objects is with short lived objects that live only for the length of a single method execution. If this is how you intend to access file system objects in .Net please read the documentation on the [Primary Way](./structures.md).

This documentation is about accessing these objects in a longer lived fashion. The factories that build these objects are static classes. Which means more care is needed when testing their interactions. It also means that fakes generated for testing may impact other parts of the system.
    

## Drive ##

### Summary

A static class that aids in getting Drive info and an enumeration of drives on the system.

It is preferable to use the [Atomic File System](./structures.md). This should only be used when you are creating long file items that live longer then a single method.

### Drive

- [2.1 Replace](#user-content-drivereplace)
- [2.2 Drive Info](#user-content-drivedriveinfo)
- [2.3 Get Drives](#user-content-drivegetdrives)
- [2.4 Build Replacement](#user-content-drivebuildreplacement)

### Drive.Replace

```csharp
public static IDisposable Replace(IStaticDriveReplacement replacement)
```

Puts the static Drive class in replacement mode. This temporarily causes the static Drive class to replace how it works.

This is used to allow testing.

***WARNING:*** This allows changing of how the system works until the returned object is disposed.

**replacement** [IStaticDriveReplacement](#user-content-static-drive-replacement)

The configuration of how to replace the inners of the static class.

**returns** [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0)

An IDisposable that when disposed reverts the static Drive class to its default behavior

***WARNING:*** This allows changing of how the system works until the returned object is disposed.

### Drive.DriveInfo

```csharp
public static IDriveInfoFactory DriveInfo { get; }
```

This returns an IDriveInfoFactory used to build information about a Drive on the system.

**returns** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md)

An IDriveInfoFactory used to build information about a Drive on the system.

### Drive.GetDrives

```csharp
public static IDriveInfo[] GetDrives();
```

Retrieves the drive names of all logical drives on a computer.

**returns** [IDriveInfo](./documentation/structures/primitives/DriveInfo.md)

An array of type IDriveInfo that represents the logical drives on a computer.

### Drive.BuildReplacement

```csharp
public static IStaticDriveReplacementBuilder BuildReplacement();
```

Returns a new builder object that makes configuring how the static Drive class behaves in replacement mode easier.

This method facilitates testing.

**returns**

A builder to build the configuration object used by the 'Replace' method.
    

## Static Drive Replacement Builder ##

TBD
    

## Static Drive Replacement ##

TBD
    

## Directory ##

TBD
    

## Static Directory Replacement Builder ##

TBD
    

## Static Directory Replacement ##

TBD
    

## File ##

TBD
    

## Static File Replacement Builder ##

TBD
    

## Static File Replacement ##

TBD
    

## Primitives ##

This links to the documentation on each of the primitives that are used by the File System Facade

1. [File Stream Factory](./documentation/structures/primitives/FileStreamFactory.md)
2. [File Stream](./documentation/structures/primitives/FileStream.md)
3. [File System Watcher Factory](./documentation/structures/primitives/FileSystemWatcherFactory.md)
4. [File System Watcher](./documentation/structures/primitives/FileSystemWatcher.md)
5. [Wait For Changed Result](./documentation/structures/primitives/WaitForChangedResult.md)
6. [Drive Info Factory](./documentation/structures/primitives/DriveInfoFactory.md)
7. [Drive Info](./documentation/structures/primitives/DriveInfo.md)
8. [File System Info](./documentation/structures/primitives/FileSystemInfo.md)
9. [Directory Info Factory](./documentation/structures/primitives/DirectoryInfoFactory.md)
10. [Directory Info](./documentation/structures/primitives/DirectoryInfo.md)
11. [File Info Factory](./documentation/structures/primitives/FileInfoFactory.md)
12. [File Info](./documentation/structures/primitives/FileInfo.md)
13. [Drives](./documentation/structures/primitives/Drives.md)
14. [Directory](./documentation/structures/primitives/Directory.md)
15. [File](./documentation/structures/primitives/File.md)
    


<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
    