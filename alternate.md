
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

The main way to access file system objects is with short lived objects that live only for the length of a single method execution. If this is how you intend to access file system objects in .Net please read the documentation on the [Primary Way](./structures.md#file-system-facades-primary-file-system-access).

This documentation is about accessing these objects in a longer lived fashion. The factories that build these objects are static classes. Which means more care is needed when testing their interactions. It also means that fakes generated for testing may impact other parts of the system.
    

## Drive ##

### Summary

A static class that aids in getting Drive info and an enumeration of drives on the system.

It is preferable to use the [Atomic File System](./structures.md#file-system-facades-primary-file-system-access). This should only be used when you are creating long file items that live longer then a single method.

### Drive

- [2.1 ReplaceStaticDriveSubSystem](#user-content-drivereplacestaticdrivesubsystem)
- [2.2 Drive Info](#user-content-drivedriveinfo)
- [2.3 Get Drives](#user-content-drivegetdrives)
- [2.4 Build Replacement](#user-content-drivebuildreplacement)

### Drive.ReplaceStaticDriveSubSystem

```csharp
public static IDisposable ReplaceStaticDriveSubSystem(IStaticDriveReplacement replacement)
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

**returns** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md#drive-info-factory)

An IDriveInfoFactory used to build information about a Drive on the system.

### Drive.GetDrives

```csharp
public static IDriveInfo[] GetDrives();
```

Retrieves the drive names of all logical drives on a computer.

**returns** [IDriveInfo](./documentation/structures/primitives/DriveInfo.md#drive-info)

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

### Summary

A builder used to aid in replacing drive items in the static file system. This object makes testing easier.

```csharp
public interface IStaticDriveReplacementBuilder
```

### IStaticDriveReplacementBuilder

- [3.1 Replace Drive Info](#user-content-istaticdrivereplacementbuilderreplacedriveinfo)
- [3.2 Replace Drives](#user-content-istaticdrivereplacementbuilderreplacedrives)
- [3.3 Build](#user-content-istaticdrivereplacementbuilderbuild)

### IStaticDriveReplacementBuilder.ReplaceDriveInfo

```csharp
IStaticDriveReplacementBuilder ReplaceDriveInfo(IDriveInfoFactory factory);
```

Configures the IDriveInfoFactory to use when the static file system is put into replacement mode.

**factory** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md#drive-info-factory)

The IDriveInfoFactory to use.

**returns** [IStaticDriveReplacementBuilder](#user-content-istaticdrivereplacementbuilder)

An instance of the builder with IDriveInfoFactory configured to be replaced.

### IStaticDriveReplacementBuilder.ReplaceDrives

```csharp
IStaticDriveReplacementBuilder ReplaceDrives(IDrives drives);
```

Configures the IDrives to use when the static file system is put into replacement mode.

**drives** [IDrives](./documentation/structures/primitives/Drives.md#drives)

The IDrives to use when the static file system is put into replacement mode.

**returns**

An instance of the builder with the IDrives configured to be replaced.

### IStaticDriveReplacementBuilder.Build

```csharp
IStaticDriveReplacement Build();
```

Builds the configuration item that is used to tell the static file system what drive based objects to use when put into replacement mode.

**returns** [IStaticDriveReplacement](#user-content-static-drive-replacement)

The configuration item that is used to tell the static file system what drive based objects to use when put into replacement mode.
    

## Static Drive Replacement ##

### Summary

The items to use in replacing drive objects in the static file system. This class makes testing easier.

```csharp
public interface IStaticDriveReplacement
```

### IStaticDriveReplacement

- [4.1 Drive Info](#user-content-istaticdrivereplacementdriveinfo)
- [4.2 Drives](#user-content-istaticdrivereplacementdrives)

### IStaticDriveReplacement.DriveInfo

```csharp
IDriveInfoFactory DriveInfo { get; }
```

Gets the IDriveInfoFactory to use when the static file system is set to replacement mode.

**returns** [IDriveInfoFactory](./documentation/structures/primitives/DriveInfoFactory.md#drive-info-factory)

The IDriveInfoFactory to use when the static file system is set to replacement mode.

### IStaticDriveReplacement.Drives

```csharp
IDrives Drives { get; }
```

Gets the IDrives to use when the static file system is set to replacement mode.

**returns** [IDrives](./documentation/structures/primitives/Drives.md#drives)

The IDrives to use when the static file system is set to replacement mode.
    

## Directory ##

### Summary

Exposes static methods for creating, moving, and enumerating through directories and subdirectories. This class cannot be inherited.

It is preferable to use the [Atomic File System](./structures.md#file-system-facades-primary-file-system-access). This should only be used when you are creating long file items that live longer then a single method.

```csharp
public static class Directory
```

### Directory

- [5.01 Directory Info](#user-content-directorydirectoryinfo)
- [5.02 FileSystem Watcher](#user-content-directoryfilesystemwatcher)
- [5.03 Create Directory](#user-content-directorycreatedirectory)
- [5.04 Delete](#user-content-directorydelete)
- [5.05 ReplaceStaticDirectorySubSystem](#user-content-directoryreplacestaticdirectorysubsystem)
- [5.06 Build Replacement](#user-content-directorybuildreplacement)
- [5.07 Enumerate Directories](#user-content-directoryenumeratedirectories)
- [5.08 Enumerate Files](#user-content-directoryenumeratefiles)
- [5.09 Enumerate File System Entries](#user-content-directoryenumeratefilesystementries)
- [5.10 Exists](#user-content-directoryexists)
- [5.11 Get Creation Time](#user-content-directorygetcreationtime)
- [5.12 Get Creation Time Utc](#user-content-directorygetcreationtimeutc)
- [5.13 Get Current Directory](#user-content-directorygetcurrentdirectory)
- [5.14 Get Directory Root](#user-content-directorygetdirectoryroot)
- [5.15 Get Files](#user-content-directorygetfiles)
- [5.16 Get File System Entries](#user-content-directorygetfilesystementries)
- [5.17 Get Last Access Time](#user-content-directorygetlastaccesstime)
- [5.18 Get Last Access Time Utc](#user-content-directorygetlastaccesstimeutc)
- [5.19 Get Last Write Time](#user-content-directorygetlastwritetime)
- [5.20 Get Last Write Time Utc](#user-content-directorygetlastwritetimeutc)
- [5.21 Get Logical Drives](#user-content-directorygetlogicaldrives)
- [5.22 Get Parent](#user-content-directorygetparent)
- [5.23 Move](#user-content-directorymove)
- [5.24 Set Creation Time](#user-content-directorysetcreationtime)
- [5.25 Set Creation Time Utc](#user-content-directorysetcreationtimeutc)
- [5.26 Set Current Directory](#user-content-directorysetcurrentdirectory)
- [5.27 Set Last Access Time](#user-content-directorysetlastaccesstime)
- [5.28 Set Last Access Time Utc](#user-content-directorysetlastaccesstimeutc)
- [5.29 Set Last Write Time](#user-content-directorysetlastwritetime)
- [5.30 Set Last Write Time Utc](#user-content-directorysetlastwritetimeutc)


### Directory.DirectoryInfo

Returns a factory to build IDirectoryInfo objects.

```csharp
public static IDirectoryInfoFactory DirectoryInfo { get; }
```
**returns** [IDirectoryInfoFactory](./documentation/structures/primitives/DirectoryInfoFactory.md#directory-info-factory)

A factory to build IDirectoryInfo objects.

### Directory.FileSystemWatcher

```csharp
public static IFileSystemWatcherFactory FileSystemWatcher { get; }
```

Returns a factory to build IFileSystemWatcher objects.

**returns** [IFileSystemWatcherFactory](./documentation/structures/primitives/FileSystemWatcherFactory.md#file-system-watcher-factory)

A factory to build IFileSystemWatcher objects.

### Directory.CreateDirectory

```csharp
public static IDirectoryInfo CreateDirectory(string path);
```

Creates all directories and subdirectories in the specified path unless they already exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The directory to create.

**returns** [IDirectoryInfo](./documentation/structures/primitives/DirectoryInfo.md#directory-info)

An object that represents the directory at the specified path. This object is returned regardless of whether a directory at the specified path already exists.

### Directory.Delete

| Signatures                                                                              |
|-----------------------------------------------------------------------------------------|
| <a href="#user-content-directorydelete1">`public static void Delete(string);`</a>       |
| <a href="#user-content-directorydelete2">`public static void Delete(string, bool);`</a> |

---

<a id="user-content-directorydelete1"></a>
```csharp
public static void Delete(string path);
```

Deletes an empty directory from a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the empty directory to remove. This directory must be writable and empty.

### Directory.Delete

<a id="user-content-directorydelete2"></a>
```csharp
public static void Delete(string path, bool recursive);
```

Deletes the specified directory and, if indicated, any subdirectories and files in the directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the directory to remove.

**recursive** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to remove directories, subdirectories, and files in path; otherwise, false.

### Directory.ReplaceStaticDirectorySubSystem

```csharp
public static IDisposable ReplaceStaticDirectorySubSystem(IStaticDirectoryReplacement replacement);
```

Puts the static Directory class in replacement mode. This allows for the temporary replacement of how the Directory class works.

This enables testing.

***WARNING:*** This allows changing of how the system works until the returned object is disposed.

**replacement** [IStaticDirectoryReplacement](#user-content-static-directory-replacement)

The configuration of how the Directory static class will function until the returned object is disposed.

**returns** [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0)

An IDisposable that when disposed will ensure that the Directory static class will return to default behaviors.

***WARNING:*** This allows changing of how the system works until the returned object is disposed.

### Directory.BuildReplacement

```csharp
public static IStaticDirectoryReplacementBuilder BuildReplacement();
```

Returns a builder that helps build the object that determines how the Directory static class works when in replacement mode.

This method facilitates testing.

**returns** [IStaticDirectoryReplacementBuilder](#user-content-static-directory-replacement-builder)

A builder that make building the configuration object used by the 'Replace' method easier.

### Directory.EnumerateDirectories

| Signatures                                                                                                                                               |
|----------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-directoryenumeratedirectories1">`public static IEnumerable<string> EnumerateDirectories(string);`</a>                             |
| <a href="#user-content-directoryenumeratedirectories2">`public static IEnumerable<string> EnumerateDirectories(string, string);`</a>                     |
| <a href="#user-content-directoryenumeratedirectories3">`public static IEnumerable<string> EnumerateDirectories(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-directoryenumeratedirectories4">`public static IEnumerable<string> EnumerateDirectories(string, string, SearchOption);`</a>       |

---

<a id="user-content-directoryenumeratedirectories1"></a>
```csharp
public static IEnumerable<string> EnumerateDirectories(string path);
```

Returns an enumerable collection of directory full names in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the directories in the directory specified by path.

---

<a id="user-content-directoryenumeratedirectories2"></a>
```csharp
public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
```

Returns an enumerable collection of directory full names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern.

---

<a id="user-content-directoryenumeratedirectories3"></a>
```csharp
public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns an enumerable collection of the directory full names that match a search pattern in a specified path, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern and enumeration options.

---

<a id="user-content-directoryenumeratedirectories4"></a>
```csharp
public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, System.IO.SearchOption searchOption);
```

Returns an enumerable collection of directory full names that match a search pattern in a specified path, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern and search option.

### Directory.EnumerateFiles

| Signatures                                                                                                                                   |
|----------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-directoryenumeratefiles1">`public static IEnumerable<string> EnumerateFiles(string, string, SearchOption);`</a>       |
| <a href="#user-content-directoryenumeratefiles2">`public static IEnumerable<string> EnumerateFiles(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-directoryenumeratefiles3">`public static IEnumerable<string> EnumerateFiles(string);`</a>                             |
| <a href="#user-content-directoryenumeratefiles4">`public static IEnumerable<string> EnumerateFiles(string, string);`</a>                     |

---

<a id="user-content-directoryenumeratefiles1"></a>
```csharp
public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, System.IO.SearchOption searchOption);
```

Returns an enumerable collection of full file names that match a search pattern in a specified path, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and search option.

---

<a id="user-content-directoryenumeratefiles2"></a>
```csharp
public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns an enumerable collection of full file names that match a search pattern and enumeration options in a specified path, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and enumeration options.

---

<a id="user-content-directoryenumeratefiles3"></a>
```csharp
public static IEnumerable<string> EnumerateFiles(string path);
```

Returns an enumerable collection of full file names in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the files in the directory specified by path.

---

<a id="user-content-directoryenumeratefiles4"></a>
```csharp
public static IEnumerable<string> EnumerateFiles(string path, string searchPattern);
```

Returns an enumerable collection of full file names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern.

### Directory.EnumerateFileSystemEntries

| Signatures                                                                                                                                                           |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-directoryenumeratefilesystementries1">`public static IEnumerable<string> EnumerateFileSystemEntries(string);`</a>                             |
| <a href="#user-content-directoryenumeratefilesystementries2">`public static IEnumerable<string> EnumerateFileSystemEntries(string, string);`</a>                     |
| <a href="#user-content-directoryenumeratefilesystementries3">`public static IEnumerable<string> EnumerateFileSystemEntries(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-directoryenumeratefilesystementries4">`public static IEnumerable<string> EnumerateFileSystemEntries(string, string, SearchOption);`</a>       |

---

<a id="user-content-directoryenumeratefilesystementries1"></a>
```csharp
public static IEnumerable<string> EnumerateFileSystemEntries(string path);
```

Returns an enumerable collection of file names and directory names in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of file-system entries in the directory specified by path.

---

<a id="user-content-directoryenumeratefilesystementries2"></a>
```csharp
public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
```

Returns an enumerable collection of file names and directory names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern.

---

<a id="user-content-directoryenumeratefilesystementries3"></a>
```csharp
public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns an enumerable collection of file names and directory names that match a search pattern and enumeration options in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of file-system entries in the directory specified by path, that match the specified search pattern and the specified enumeration options.

---

<a id="user-content-directoryenumeratefilesystementries4"></a>
```csharp
public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, System.IO.SearchOption searchOption);
```

Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.

### Directory.Exists

```csharp
public static bool Exists(string? path);
```

Determines whether the given path refers to an existing directory on disk.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to test.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true if path refers to an existing directory; false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.

### Directory.GetCreationTime

```csharp
public static DateTime GetCreationTime(string path);
```

Gets the creation date and time of a directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the directory.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A structure that is set to the creation date and time for the specified directory. This value is expressed in local time.

### Directory.GetCreationTimeUtc

```csharp
public static DateTime GetCreationTimeUtc(string path);
```

Gets the current working directory of the application.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A string that contains the absolute path of the current working directory, and does not end with a backslash (\).

### Directory.GetCurrentDirectory

```csharp
public static string GetCurrentDirectory();
```

Gets the current working directory of the application.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string that contains the absolute path of the current working directory, and does not end with a backslash (\).

### Directory.GetDirectories

| Signatures                                                                                                                        |
|-----------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-directorygetdirectories1">`public static string[] GetDirectories(string, string, SearchOption);`</a>       |
| <a href="#user-content-directorygetdirectories2">`public static string[] GetDirectories(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-directorygetdirectories3">`public static string[] GetDirectories(string);`</a>                             |
| <a href="#user-content-directorygetdirectories4">`public static string[] GetDirectories(string, string);`</a>                     |

---

<a id="user-content-directorygetdirectories1"></a>
```csharp
public static string[] GetDirectories(string path, string searchPattern, System.IO.SearchOption searchOption);
```

Returns the names of the subdirectories (including their paths) that match the specified search pattern in the specified directory, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include all subdirectories or only the current directory.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) of the subdirectories that match the specified criteria, or an empty array if no directories are found.

---

<a id="user-content-directorygetdirectories2"></a>
```csharp
public static string[] GetDirectories(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns the names of subdirectories (including their paths) that match the specified search pattern and enumeration options in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) of the subdirectories that match the search pattern and enumeration options in the specified directory, or an empty array if no directories are found.

---

<a id="user-content-directorygetdirectories3"></a>
```csharp
public static string[] GetDirectories(string path);
```

Returns the names of subdirectories (including their paths) in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) of subdirectories in the specified path, or an empty array if no directories are found.

---

<a id="user-content-directorygetdirectories4"></a>
```csharp
public static string[] GetDirectories(string path, string searchPattern);
```

Returns the names of subdirectories (including their paths) that match the specified search pattern in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) of the subdirectories that match the search pattern in the specified directory, or an empty array if no directories are found.

### Directory.GetDirectoryRoot

```csharp
public static string GetDirectoryRoot(string path);
```

Returns the volume information, root information, or both for the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of a file or directory.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string that contains the volume information, root information, or both for the specified path.

### Directory.GetFiles

| Signatures                                                                                                                 |
|----------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-directorygetfiles1">`public static string[] GetFiles(string);`</a>                                  |
| <a href="#user-content-directorygetfiles2">`public static string[] GetFiles(string, string);`</a>                          |
| <a href="#user-content-directorygetfiles3">`public static string[] GetFiles(path, searchPattern, EnumerationOptions);`</a> |
| <a href="#user-content-directorygetfiles4">`public static string[] GetFiles(string, string, SearchOption);`</a>            |

---

<a id="user-content-directorygetfiles1"></a>
```csharp
public static string[] GetFiles(string path);
```

Returns the names of files (including their paths) in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) for the files in the specified directory, or an empty array if no files are found.

---

<a id="user-content-directorygetfiles2"></a>
```csharp
public static string[] GetFiles(string path, string searchPattern);
```

Returns the names of files (including their paths) that match the specified search pattern in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) for the files in the specified directory that match the specified search pattern, or an empty array if no files are found.

---

<a id="user-content-directorygetfiles3"></a>
```csharp
public static string[] GetFiles(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns the names of files (including their paths) that match the specified search pattern and enumeration options in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) for the files in the specified directory that match the specified search pattern and enumeration options, or an empty array if no files are found.

---

<a id="user-content-directorygetfiles4"></a>
```csharp
public static string[] GetFiles(string path, string searchPattern, System.IO.SearchOption searchOption);
```

Returns the names of files (including their paths) that match the specified search pattern in the specified directory, using a value to determine whether to search subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include all subdirectories or only the current directory.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) for the files in the specified directory that match the specified search pattern and option, or an empty array if no files are found.

### Directory.GetFileSystemEntries

| Signatures                                                                                                                                    |
|-----------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-directorygetfilesystementries1">`public static string[] GetFileSystemEntries(string);`</a>                             |
| <a href="#user-content-directorygetfilesystementries2">`public static string[] GetFileSystemEntries(string, string);`</a>                     |
| <a href="#user-content-directorygetfilesystementries3">`public static string[] GetFileSystemEntries(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-directorygetfilesystementries4">`public static string[] GetFileSystemEntries(string, string, SearchOption);`</a>       |

---

<a id="user-content-directorygetfilesystementries1"></a>
```csharp
public static string[] GetFileSystemEntries(string path);
```

Returns the names of all files and subdirectories in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the names of files and subdirectories in the specified directory, or an empty array if no files or subdirectories are found.

---

<a id="user-content-directorygetfilesystementries2"></a>
```csharp
public static string[] GetFileSystemEntries(string path, string searchPattern);
```

Returns an array of file names and directory names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of file and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.

---

<a id="user-content-directorygetfilesystementries3"></a>
```csharp
public static string[] GetFileSystemEntries(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns an array of file names and directory names that match a search pattern and enumeration options in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of file names and directory names that match the specified search pattern and enumeration options, or an empty array if no files or directories are found.

---

<a id="user-content-directorygetfilesystementries4"></a>
```csharp
public static string[] GetFileSystemEntries(string path, string searchPattern, System.IO.SearchOption searchOption);
```

Returns an array of all the file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption**[System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of file the file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.

### Directory.GetLastAccessTime

```csharp
public static DateTime GetLastAccessTime(string path);
```

Returns the date and time the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.

### Directory.GetLastAccessTimeUtc

```csharp
public static DateTime GetLastAccessTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.

### Directory.GetLastWriteTime

```csharp
public static DateTime GetLastWriteTime(string path);
```

Returns the date and time the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in local time.

### Directory.GetLastWriteTimeUtc

```csharp
public static DateTime GetLastWriteTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in UTC time.

### Directory.GetLogicalDrives

```csharp
public static string[] GetLogicalDrives();
```

Retrieves the names of the logical drives on this computer in the form "<drive letter>:\".

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The logical drives on this computer.

### Directory.GetParent

```csharp
public static IDirectoryInfo? GetParent(string path);
```

Retrieves the parent directory of the specified path, including both absolute and relative paths.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path for which to retrieve the parent directory.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IDirectoryInfo](./documentation/structures/primitives/DirectoryInfo.md#directory-info)\>

The parent directory, or null if path is the root directory, including the root of a UNC server or share name.

### Directory.Move

```csharp
public static void Move(string sourceDirName, string destDirName);
```

Moves a file or a directory and its contents to a new location.

**sourceDirName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the file or directory to move.

**destDirName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the new location for sourceDirName or its contents. If sourceDirName is a file, then destDirName must also be a file name.

### Directory.SetCreationTime

```csharp
public static void SetCreationTime(string path, DateTime creationTime);
```

Sets the creation date and time for the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the creation date and time information.

**creationTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The date and time the file or directory was last written to. This value is expressed in local time.

### Directory.SetCreationTimeUtc

```csharp
public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
```

Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the creation date and time information.

**creationTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The date and time the directory or file was created. This value is expressed in local time.

### Directory.SetCurrentDirectory

```csharp
public static void SetCurrentDirectory(string path);
```

Sets the application's current working directory to the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to which the current working directory is set.

### Directory.SetLastAccessTime

```csharp
public static void SetLastAccessTime(string path, DateTime lastAccessTime);
```

Sets the date and time the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the access date and time information.

**lastAccessTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

An object that contains the value to set for the access date and time of path. This value is expressed in local time.

### Directory.SetLastAccessTimeUtc

```csharp
public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
```

Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the access date and time information.

**lastAccessTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

An object that contains the value to set for the access date and time of path. This value is expressed in UTC time.

### Directory.SetLastWriteTime

```csharp
public static void SetLastWriteTime(string path, DateTime lastWriteTime);
```

Sets the date and time a directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the directory.

**lastWriteTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The date and time the directory was last written to. This value is expressed in local time.

### Directory.SetLastWriteTimeUtc

```csharp
public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the date and time information.

**lastWriteTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last write date and time of path. This value is expressed in UTC time.
    

## Static Directory Replacement Builder ##

### Summary

This is a builder that helps setup the configuration of Directory objects to replace when the static file system is put into replacement mode. This object helps with testing.

```csharp
public interface IStaticDirectoryReplacementBuilder
```

### IStaticDirectoryReplacementBuilder

- [6.1 Replace Directory Info](#user-content-istaticdirectoryreplacementbuilderreplacedirectoryinfo)
- [6.2 Replace Directory](#user-content-istaticdirectoryreplacementbuilderreplacedirectory)
- [6.3 Replace File System Watcher](#user-content-istaticdirectoryreplacementbuilderreplacefilesystemwatcher)
- [6.4 Build](#user-content-istaticdirectoryreplacementbuilderbuild)

### IStaticDirectoryReplacementBuilder.ReplaceDirectoryInfo

```csharp
IStaticDirectoryReplacementBuilder ReplaceDirectoryInfo(IDirectoryInfoFactory factory);
```

Configures the IDirectoryInfoFactory to use when the static file system is put into replacement mode.

**factory** [IDirectoryInfoFactory](./documentation/structures/primitives/DirectoryInfoFactory.md#directory-info-factory)

The IDirectoryInfoFactory to use when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacementBuilder](#user-content-istaticdirectoryreplacementbuilder)

An instance of the builder with the IDirectoryInfo configured to be replaced when the static file system is put into replacement mode.

### IStaticDirectoryReplacementBuilder.ReplaceDirectory

```csharp
IStaticDirectoryReplacementBuilder ReplaceDirectory(IDirectory newDirectory);
```

Configures the IDirectory to use when the static file system is put into replacement mode.

**newDirectory** [IDirectory](./documentation/structures/primitives/Directory.md#directory)

The IDirectory to use when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacementBuilder](#user-content-istaticdirectoryreplacementbuilder)

An instance of the builder with the IDirectory configured to be replaced when the static file system is put into replacement mode.

### IStaticDirectoryReplacementBuilder.ReplaceFileSystemWatcher

```csharp
IStaticDirectoryReplacementBuilder ReplaceFileSystemWatcher(IFileSystemWatcherFactory factory);
```

Configures the IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

**factory** [IFileSystemWatcherFactory](./documentation/structures/primitives/FileSystemWatcherFactory.md#file-system-watcher-factory)

The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacementBuilder](#user-content-istaticdirectoryreplacementbuilder)

An instance of the builder with the IFilesSystemWatcherFactory configured to be replaced when the static file system is put into replacement mode.

### IStaticDirectoryReplacementBuilder.Build

```csharp
IStaticDirectoryReplacement Build();
```

Builds the configuration object used when the static file system is put into replacement mode.

**returns** [IStaticDirectoryReplacement](#user-content-static-directory-replacement)

The configuration object used when the static file system is put into replacement mode.
    

## Static Directory Replacement ##

### Summary

A class that configures what directory objects to use when the static file system is put into replacement mode. This object makes testing easier.

```csharp
public interface IStaticDirectoryReplacement
```

### IStaticDirectoryReplacement

- [7.1 File System Watcher](#user-content-istaticdirectoryreplacementfilesystemwatcher)
- [7.2 Director Info](#user-content-istaticdirectoryreplacementdirectorinfo)
- [7.3 Directory](#user-content-istaticdirectoryreplacementdirectory)

### IStaticDirectoryReplacement.FileSystemWatcher

```csharp
IFileSystemWatcherFactory FileSystemWatcher { get; }
```

The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

**returns** [IFileSystemWatcherFactory](./documentation/structures/primitives/FileSystemWatcherFactory.md#file-system-watcher-factory)

The IFilesSystemWatcherFactory to use when the static file system is put into replacement mode.

### IStaticDirectoryReplacement.DirectorInfo

```csharp
IDirectoryInfoFactory DirectorInfo { get; }
```

The IDirectoryInfoFactory to use when the static file system is put into replacement mode.

**returns** [IDirectoryInfoFactory](./documentation/structures/primitives/DirectoryInfoFactory.md#directory-info-factory)

The IDirectoryInfoFactory to use when the static file system is put into replacement mode.

### IStaticDirectoryReplacement.Directory

```csharp
IDirectory Directory { get; }
```

The IDirectory to use when the static file system is put into replacement mode.

**returns** [IDirectory](./documentation/structures/primitives/Directory.md#directory)

The IDirectory to use when the static file system is put into replacement mode.
    

## File ##

### Summary

This is to replace the [System.IO.File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-6.0) object. Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the creation of IFileStream objects.

It is preferable to use the [Atomic File System](./structures.md#file-system-facades-primary-file-system-access). This should only be used when you are creating long file items that live longer then a single method.

```csharp
public static class File
```

### File

- [8.01 Replace Static File Sub System](#user-content-filereplacestaticfilesubsystem)
- [8.02 Build Replacement](#user-content-filebuildreplacement)
- [8.03 File Info Factory](#user-content-filefileinfofactory)
- [8.04 File Stream Factory](#user-content-filefilestreamfactory)
- [8.05 Append All Lines](#user-content-fileappendalllines)
- [8.06 Append All Lines Async](#user-content-fileappendalllinesasync)
- [8.07 Append All Text](#user-content-fileappendalltext)
- [8.08 Append All Text Async](#user-content-fileappendalltextasync)
- [8.09 Append Text](#user-content-fileappendtext)
- [8.10 Copy](#user-content-filecopy)
- [8.11 Create](#user-content-filecreate)
- [8.12 Create Text](#user-content-filecreatetext)
- [8.13 Delete](#user-content-filedelete)
- [8.13 Exists](#user-content-fileexists)
- [8.14 Get Attributes](#user-content-filegetattributes)
- [8.15 Get Creation Time](#user-content-filegetcreationtime)
- [8.16 Get Creation Time Utc](#user-content-filegetcreationtimeutc)
- [8.17 Get Last Access Time](#user-content-filegetlastaccesstime)
- [8.18 Get Last Access Time Utc](#user-content-filegetlastaccesstimeutc)
- [8.19 Get Last Write Time](#user-content-filegetlastwritetime)
- [8.20 Get Last Write Time Utc](#user-content-filegetlastwritetimeutc)
- [8.21 Move](#user-content-filemove)
- [8.22 Open](#user-content-fileopen)
- [8.23 Open Read](#user-content-fileopenread)
- [8.24 Open Text](#user-content-fileopentext)
- [8.25 Open Write](#user-content-fileopenwrite)
- [8.26 Read All Bytes](#user-content-filereadallbytes)
- [8.27 Read All Bytes Async](#user-content-filereadallbytesasync)
- [8.28 Read All Lines](#user-content-filereadalllines)
- [8.29 Read All Lines Async](#user-content-filereadalllinesasync)
- [8.30 Read All Text](#user-content-filereadalltext)
- [8.31 Read All Text Async](#user-content-filereadalltextasync)
- [8.32 Read Lines](#user-content-filereadlines)
- [8.33 Replace](#user-content-filereplace)
- [8.34 Set Attributes](#user-content-filesetattributes)
- [8.35 Set Creation Time](#user-content-filesetcreationtime)
- [8.36 Set Creation Time Utc](#user-content-filesetcreationtimeutc)
- [8.37 Set Last Access Time](#user-content-filesetlastaccesstime)
- [8.38 Set Last Access Time Utc](#user-content-filesetlastaccesstimeutc)
- [8.39 Set Last Write Time](#user-content-filesetlastwritetime)
- [8.40 Set Last Write Time Utc](#user-content-filesetlastwritetimeutc)
- [8.41 Write All Bytes](#user-content-filewriteallbytes)
- [8.42 Write All Bytes Async](#user-content-filewriteallbytesasync)
- [8.43 Write All Lines](#user-content-filewritealllines)
- [8.44 Write All Lines Async](#user-content-filewritealllinesasync)
- [8.45 Write All Text](#user-content-filewritealltext)
- [8.46 Write All Text Async](#user-content-filewritealltextasync)
- [8.47 Decrypt](#user-content-filedecrypt)
- [8.48 Encrypt](#user-content-fileencrypt)

<!--
#user-content-file
-->

### File.ReplaceStaticFileSubSystem

```csharp
public static IDisposable ReplaceStaticFileSubSystem(IStaticFileReplacement replacement);
```

Puts the static File object into replacement mode. This is used to allow testing. It changes the way the static File class behaves.

***WARNING:*** the static File's behavior will be changed until dispose is called on the returned value.

**replacement** [IStaticFileReplacement](#user-content-static-file-replacement)

Configures how the underlying class behaves.

**returns** [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0)

An IDisposable that when disposed returns the static File class to its default behavior.

***WARNING:*** the static File's behavior will be changed until dispose is called on the returned value.

### File.BuildReplacement

```csharp
public static IStaticFileReplacementBuilder BuildReplacement();
```

Is used to aid in the building of the configuration object used in the 'Replace' method.

This is only used to facilitate testing.

**returns** [IStaticFileReplacementBuilder](#user-content-static-file-replacement-builder)

A builder that allows for the replacement of only items that need to be replaced to enable testing.

### File.FileInfoFactory

```csharp
public static IFileInfoFactory FileInfoFactory { get; }
```

Returns a factory that enables the creation of IFileInfo objects.

**returns** [IFileInfoFactory](./documentation/structures/primitives/FileInfoFactory.md#file-info-factory)

A factory that enables the creation of IFileInfo objects.

### File.FileStreamFactory

```csharp
public static IFileStreamFactory? FileStreamFactory { get; }
```

Returns a factory that enables the creation of IFileStream objects.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IFileStreamFactory](./documentation/structures/primitives/FileStreamFactory.md#file-stream-factory)\>

A factory that enables the creation of IFileStream objects.

### File.AppendAllLines

| Signatures                                                                                                                  |
|-----------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalllines1">`public static void AppendAllLines(string, IEnumerable<string>);`</a>           |
| <a href="#user-content-fileappendalllines2">`public static void AppendAllLines(string, IEnumerable<string>, Encoding);`</a> |

---

<a id="user-content-fileappendalllines1"></a>
```csharp
public static void AppendAllLines(string path, IEnumerable<string> contents);
```

Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

---

<a id="user-content-fileappendalllines2"></a>
```csharp
public static void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
```

Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

### File.AppendAllLinesAsync

| Signatures                                                                                                                                               |
|----------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalllinesasync1">`public static Task AppendAllLinesAsync(string, IEnumerable<string>, CancellationToken);`</a>           |
| <a href="#user-content-fileappendalllinesasync2">`public static Task AppendAllLinesAsync(string, IEnumerable<string>, Encoding, CancellationToken);`</a> |

---

<a id="user-content-fileappendalllinesasync1"></a>
```csharp
public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
```

Asynchronously appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

---

<a id="user-content-fileappendalllinesasync2"></a>
```csharp
public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the lines to. The file is created if it doesn't already exist.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

### File.AppendAllText

| Signatures                                                                                                    |
|---------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalltext1">`public static void AppendAllText(string, string?);`</a>           |
| <a href="#user-content-fileappendalltext2">`public static void AppendAllText(string, string?, Encoding);`</a> |

---

<a id="user-content-fileappendalltext1"></a>
```csharp
public static void AppendAllText(string path, string? contents);
```

Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

---

<a id="user-content-fileappendalltext2"></a>
```csharp
public static void AppendAllText(string path, string? contents, Encoding encoding);
```

Appends the specified string to the file using the specified encoding, creating the file if it does not already exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

### File.AppendAllTextAsync

| Signatures                                                                                                                                 |
|--------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileappendalltextasync1">`public static Task AppendAllTextAsync(string, string?, CancellationToken);`</a>           |
| <a href="#user-content-fileappendalltextasync2">`public static Task AppendAllTextAsync(string, string?, Encoding, CancellationToken);`</a> |

---

<a id="user-content-fileappendalltextasync1"></a>
```csharp
public static Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);
```

Asynchronously opens a file or creates a file if it does not already exist, appends the specified string to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

---

<a id="user-content-fileappendalltextasync2"></a>
```csharp
public static Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to append the specified string to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to append to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous append operation.

### File.AppendText

```csharp
public static System.IO.StreamWriter AppendText(string path);
```

Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file does not exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file to append to.

**returns** [System.IO.StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0)

A stream writer that appends UTF-8 encoded text to the specified file or to a new file.

### File.Copy

| Signatures                                                                             |
|----------------------------------------------------------------------------------------|
| <a href="#user-content-filecopy1">`public static void Copy(string, string);`</a>       |
| <a href="#user-content-filecopy2">`public static void Copy(string, string, bool);`</a> |

---

<a id="user-content-filecopy1"></a>
```csharp
public static void Copy(string sourceFileName, string destFileName);
```

Copies an existing file to a new file. Overwriting a file of the same name is not allowed.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to copy.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the destination file. This cannot be a directory or an existing file.

---

<a id="user-content-filecopy2"></a>
```csharp
public static void Copy(string sourceFileName, string destFileName, bool overwrite);
```

Copies an existing file to a new file. Overwriting a file of the same name is allowed.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to copy.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the destination file. This cannot be a directory.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true if the destination file can be overwritten; otherwise, false.

### File.Create

| Signatures                                                                                            |
|-------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filecreate1">`public static IFileStream Create(string);`</a>                   |
| <a href="#user-content-filecreate2">`public static IFileStream Create(string, int);`</a>              |
| <a href="#user-content-filecreate3">`public static IFileStream Create(string, int, FileOptions);`</a> |

---

<a id="user-content-filecreate1"></a>
```csharp
public static IFileStream Create(string path);
```

Creates or overwrites a file in the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path and name of the file to create.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream that provides read/write access to the file specified in path.

---

<a id="user-content-filecreate2"></a>
```csharp
public static IFileStream Create(string path, int bufferSize);
```

The path and name of the file to create.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream with the specified buffer size that provides read/write access to the file specified in path.

---

<a id="user-content-filecreate3"></a>
```csharp
public static IFileStream Create(string path, int bufferSize, System.IO.FileOptions options);
```

Creates or overwrites a file in the specified path, specifying a buffer size and options that describe how to create or overwrite the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path and name of the file to create.

**bufferSize** [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-6.0)

The number of bytes buffered for reads and writes to the file.

**options** [System.IO.FileOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileoptions?view=net-6.0)

One of the FileOptions values that describes how to create or overwrite the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A new file with the specified buffer size.

### File.CreateText

```csharp
public static System.IO.StreamWriter CreateText(string path);
```

Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for writing.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A StreamWriter that writes to the specified file using UTF-8 encoding.

### File.Delete

```csharp
public static void Delete(string path);
```

Deletes the specified file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to be deleted. Wildcard characters are not supported.

### File.Exists

```csharp
public static bool Exists(string? path);
```

Determines whether the specified file exists.

**path** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The file to check.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true if the caller has the required permissions and path contains the name of an existing file; otherwise, false. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.

### File.GetAttributes

```csharp
public static System.IO.FileAttributes GetAttributes(string path);
```

Gets the FileAttributes of the file on the path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file.

**returns** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

The FileAttributes of the file on the path.

### File.GetCreationTime

```csharp
public static DateTime GetCreationTime(string path);
```

Returns the creation date and time of the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain creation date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in local time.

### File.GetCreationTimeUtc

```csharp
public static DateTime GetCreationTimeUtc(string path);
```

Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain creation date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the creation date and time for the specified file or directory. This value is expressed in UTC time.

### File.GetLastAccessTime

```csharp
public static DateTime GetLastAccessTime(string path);
```

Returns the date and time the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.

### File.GetLastAccessTimeUtc

```csharp
public static DateTime GetLastAccessTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.

### File.GetLastWriteTime

```csharp
public static DateTime GetLastWriteTime(string path);
```

Returns the date and time the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in local time.

### File.GetLastWriteTimeUtc

```csharp
public static DateTime GetLastWriteTimeUtc(string path);
```

Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain write date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime structure set to the date and time that the specified file or directory was last written to. This value is expressed in UTC time.

### File.Move

| Signature                                                                              |
|----------------------------------------------------------------------------------------|
| <a href="#user-content-filemove1">`public static void Move(string, string);`</a>       |
| <a href="#user-content-filemove2">`public static void Move(string, string, bool);`</a> |

---

<a id="user-content-filemove1"></a>
```csharp
public static void Move(string sourceFileName, string destFileName);
```

Moves a specified file to a new location, providing the option to specify a new file name.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to move. Can include a relative or absolute path.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The new path and name for the file.

---

<a id="user-content-filemove2"></a>
```csharp
public static void Move(string sourceFileName, string destFileName, bool overwrite);
```

Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the destination file if it already exists.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file to move. Can include a relative or absolute path.

**destFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The new path and name for the file.

**overwrite** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to overwrite the destination file if it already exists; false otherwise.

### File.Open

| Signatures                                                                                                       |
|------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-fileopen1">`public static IFileStream Open(string, FileMode);`</a>                        |
| <a href="#user-content-fileopen2">`public static IFileStream Open(string, FileMode, FileAccess);`</a>            |
| <a href="#user-content-fileopen3">`public static IFileStream Open(string, FileMode, FileAccess, FileShare);`</a> |

---

<a id="user-content-fileopen1"></a>
```csharp
public static IFileStream Open(string path, System.IO.FileMode mode);
```

Opens a FileStream on the specified path with read/write access with no sharing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream opened in the specified mode and path, with read/write access and not shared.

---

<a id="user-content-fileopen2"></a>
```csharp
public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access);
```

Opens a FileStream on the specified path, with the specified mode and access with no sharing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A FileAccess value that specifies the operations that can be performed on the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

An unshared FileStream that provides access to the specified file, with the specified mode and access.

---

<a id="user-content-fileopen3"></a>
```csharp
public static IFileStream Open(string path, System.IO.FileMode mode, System.IO.FileAccess access, System.IO.FileShare share);
```

Opens a FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open.

**mode** [System.IO.FileMode](https://docs.microsoft.com/en-us/dotnet/api/system.io.filemode?view=net-6.0)

A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.

**access** [System.IO.FileAccess](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=net-6.0)

A FileAccess value that specifies the operations that can be performed on the file.

**share** [System.IO.FileShare](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare?view=net-6.0)

A FileShare value specifying the type of access other threads have to the file.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.

### File.OpenRead

```csharp
public static IFileStream OpenRead(string path);
```

Opens an existing file for reading.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for reading.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

A read-only FileStream on the specified path.

### File.OpenText

```csharp
public static System.IO.StreamReader OpenText(string path);
```

Opens an existing UTF-8 encoded text file for reading.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for reading.

**returns** [System.IO.StreamReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-6.0)

A StreamReader on the specified path.

### File.OpenWrite

```csharp
public static IFileStream OpenWrite(string path);
```

Opens an existing file or creates a new file for writing.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to be opened for writing.

**returns** [IFileStream](./documentation/structures/primitives/FileStream.md#file-stream)

An unshared FileStream object on the specified path with Write access.

### File.ReadAllBytes

```csharp
public static byte[] ReadAllBytes(string path);
```

Opens a binary file, reads the contents of the file into a byte array, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

A byte array containing the contents of the file.

### File.ReadAllBytesAsync

```csharp
public static Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the byte array containing the contents of the file.

### File.ReadAllLines

| Signatures                                                                                             |
|--------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalllines1">`public static string[] ReadAllLines(string);`</a>           |
| <a href="#user-content-filereadalllines2">`public static string[] ReadAllLines(string, Encoding);`</a> |

---

<a id="user-content-filereadalllines1"></a>
```csharp
public static string[] ReadAllLines(string path);
```

Opens a text file, reads all lines of the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A string array containing all lines of the file.

---

<a id="user-content-filereadalllines2"></a>
```csharp
public static string[] ReadAllLines(string path, Encoding encoding);
```

Opens a file, reads all lines of the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A string array containing all lines of the file.

### File.ReadAllLinesAsync

| Signatures                                                                                                                                |
|-------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalllinesasync1">`public static Task<string[]> ReadAllLinesAsync(string, CancellationToken);`</a>           |
| <a href="#user-content-filereadalllinesasync2">`public static Task<string[]> ReadAllLinesAsync(string, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filereadalllinesasync1"></a>
```csharp
public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all lines of the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the string array containing all lines of the file.

---

<a id="user-content-filereadalllinesasync2"></a>
```csharp
public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all lines of the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>\>

A task that represents the asynchronous read operation, which wraps the string array containing all lines of the file.

### File.ReadAllText

| Signatures                                                                                         |
|----------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalltext1">`public static string ReadAllText(string, Encoding);`</a> |
| <a href="#user-content-filereadalltext2">`public static string ReadAllText(string);`</a>           |

---

<a id="user-content-filereadalltext1"></a>
```csharp
public static string ReadAllText(string path, Encoding encoding);
```

Opens a file, reads all text in the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string containing all text in the file.

---

<a id="user-content-filereadalltext2"></a>
```csharp
public static string ReadAllText(string path);
```

Opens a text file, reads all the text in the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string containing all the text in the file.

### File.ReadAllTextAsync

| Signatures                                                                                                                            |
|---------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadalltextasync1">`public static Task<string> ReadAllTextAsync(string, CancellationToken);`</a>           |
| <a href="#user-content-filereadalltextasync2">`public static Task<string> ReadAllTextAsync(string, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filereadalltextasync1"></a>
```csharp
public static Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all the text in the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A task that represents the asynchronous read operation, which wraps the string containing all text in the file.

---

<a id="user-content-filereadalltextasync2"></a>
```csharp
public static Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously opens a text file, reads all text in the file with the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to open for reading.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding applied to the contents of the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A task that represents the asynchronous read operation, which wraps the string containing all text in the file.

### File.ReadLines

| Signatures                                                                                                  |
|-------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereadlines1">`public static IEnumerable<string> ReadLines(string);`</a>           |
| <a href="#user-content-filereadlines2">`public static IEnumerable<string> ReadLines(string, Encoding);`</a> |

---

<a id="user-content-filereadlines1"></a>
```csharp
public static IEnumerable<string> ReadLines(string path);
```

Reads the lines of a file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to read.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

All the lines of the file, or the lines that are the result of a query.

---

<a id="user-content-filereadlines2"></a>
```csharp
public static IEnumerable<string> ReadLines(string path, Encoding encoding);
```

Read the lines of a file that has a specified encoding.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to read.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding that is applied to the contents of the file.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

All the lines of the file, or the lines that are the result of a query.

### File.Replace

| Signatures                                                                                            |
|-------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filereplace1">`public static void Replace(string, string, string?);`</a>       |
| <a href="#user-content-filereplace2">`public static void Replace(string, string, string?, bool);`</a> |

---

<a id="user-content-filereplace1"></a>
```csharp
public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName);
```

Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a file that replaces the file specified by destinationFileName.

**destinationFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file being replaced.

**destinationBackupFileName** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the backup file.

---

<a id="user-content-filereplace2"></a>
```csharp
public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors);
```

Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file and optionally ignores merge errors.

**sourceFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of a file that replaces the file specified by destinationFileName.

**destinationFileName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the file being replaced.

**destinationBackupFileName** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The name of the backup file.

**ignoreMetadataErrors** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to ignore merge errors (such as attributes and access control lists (ACLs)) from the replaced file to the replacement file; otherwise, false.

### File.SetAttributes

```csharp
public static void SetAttributes(string path, System.IO.FileAttributes fileAttributes);
```

Sets the specified FileAttributes of the file on the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the file.

**fileAttributes** [System.IO.FileAttributes](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=net-6.0)

A bitwise combination of the enumeration values.

### File.SetCreationTime

```csharp
public static void SetCreationTime(string path, DateTime creationTime);
```

Sets the date and time the file was created.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the creation date and time information.

**creationTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the creation date and time of path. This value is expressed in local time.

### File.SetCreationTimeUtc

```csharp
public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the file was created.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the creation date and time information.

**creationTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the creation date and time of path. This value is expressed in UTC time.

### File.SetLastAccessTime

```csharp
public static void SetLastAccessTime(string path, DateTime lastAccessTime);
```

Sets the date and time the specified file was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the access date and time information.

**lastAccessTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last access date and time of path. This value is expressed in local time.

### File.SetLastAccessTimeUtc

```csharp
public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the access date and time information.

**lastAccessTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last access date and time of path. This value is expressed in UTC time.

### File.SetLastWriteTime

```csharp
public static void SetLastWriteTime(string path, DateTime lastWriteTime);
```

Sets the date and time that the specified file was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the date and time information.

**lastWriteTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last write date and time of path. This value is expressed in local time.

### File.SetLastWriteTimeUtc

```csharp
public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
```

Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file for which to set the date and time information.

**lastWriteTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A DateTime containing the value to set for the last write date and time of path. This value is expressed in UTC time.

### File.WriteAllBytes

```csharp
public static void WriteAllBytes(string path, byte[] bytes);
```

Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**bytes** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The bytes to write to the file.

### File.WriteAllBytesAsync

```csharp
public static Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**bytes** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte?view=net-6.0)\>

The bytes to write to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

### File.WriteAllLines

| Signatures                                                                                                                |
|---------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealllines1">`public static void WriteAllLines(string, string[], Encoding);`</a>            |
| <a href="#user-content-filewritealllines2">`public static void WriteAllLines(string, IEnumerable<string>, Encoding);`</a> |
| <a href="#user-content-filewritealllines3">`public static void WriteAllLines(string, IEnumerable<string>);`</a>           |
| <a href="#user-content-filewritealllines4">`public static void WriteAllLines(string, string[]);`</a>                      |

---

<a id="user-content-filewritealllines1"></a>
```csharp
public static void WriteAllLines(string path, string[] contents, Encoding encoding);
```

Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string array to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

An Encoding object that represents the character encoding applied to the string array.

---

<a id="user-content-filewritealllines2"></a>
```csharp
public static void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
```

Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

---

<a id="user-content-filewritealllines3"></a>
```csharp
public static void WriteAllLines(string path, IEnumerable<string> contents);
```

Creates a new file, writes a collection of strings to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

---

<a id="user-content-filewritealllines4"></a>
```csharp
public static void WriteAllLines(string path, string[] contents);
```

Creates a new file, write the specified string array to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string array to write to the file.

### File.WriteAllLinesAsync

| Signatures                                                                                                                                             |
|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealllinesasync1">`public static Task WriteAllLinesAsync(string, IEnumerable<string>, CancellationToken);`</a>           |
| <a href="#user-content-filewritealllinesasync2">`public static Task WriteAllLinesAsync(string, IEnumerable<string>, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filewritealllinesasync1"></a>
```csharp
public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified lines to the file, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

---

<a id="user-content-filewritealllinesasync2"></a>
```csharp
public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, write the specified lines to the file by using the specified encoding, and then closes the file.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The lines to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The character encoding to use.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

### File.WriteAllText

| Signatures                                                                                                  |
|-------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealltext1">`public static void WriteAllText(string, string?);`</a>           |
| <a href="#user-content-filewritealltext2">`public static void WriteAllText(string, string?, Encoding);`</a> |

---

<a id="user-content-filewritealltext1"></a>
```csharp
public static void WriteAllText(string path, string? contents);
```

Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

---

<a id="user-content-filewritealltext2"></a>
```csharp
public static void WriteAllText(string path, string? contents, Encoding encoding);
```

Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding to apply to the string.

### File.WriteAllTextAsync

| Signatures                                                                                                                               |
|------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-filewritealltextasync1">`public static Task WriteAllTextAsync(string, string?, CancellationToken);`</a>           |
| <a href="#user-content-filewritealltextasync2">`public static Task WriteAllTextAsync(string, string?, Encoding, CancellationToken);`</a> |

---

<a id="user-content-filewritealltextasync1"></a>
```csharp
public static Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

---

<a id="user-content-filewritealltextasync2"></a>
```csharp
public static Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default);
```

Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file to write to.

**contents** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The string to write to the file.

**encoding** [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0)

The encoding to apply to the string.

**cancellationToken** [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0)

The token to monitor for cancellation requests. The default value is None.

**returns** [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)

A task that represents the asynchronous write operation.

### File.Decrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public static void Decrypt(string path);
```

Decrypts a file that was encrypted by the current account using the Encrypt(String) method.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A path that describes a file to decrypt.

### File.Encrypt

```csharp
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public static void Encrypt(string path);
```

Encrypts a file so that only the account used to encrypt the file can decrypt it.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A path that describes a file to encrypt.
    

## Static File Replacement Builder ##

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

### IStaticFileReplacementBuilder.Build

```csharp
IStaticFileReplacement Build();
```

Builds the replacement configuration used by the Static File System objects with the configured items for replacement.

**returns** [IStaticFileReplacement](#user-content-static-file-replacement)

An instance of the configuration used to do replacement in the static file system objects.
    

## Static File Replacement ##

TBD
    

## Primitives ##

This links to the documentation on each of the primitives that are used by the File System Facade

1. [File Stream Factory](./documentation/structures/primitives/FileStreamFactory.md#file-stream-factory)
2. [File Stream](./documentation/structures/primitives/FileStream.md#file-stream)
3. [File System Watcher Factory](./documentation/structures/primitives/FileSystemWatcherFactory.md#file-system-watcher-factory)
4. [File System Watcher](./documentation/structures/primitives/FileSystemWatcher.md#file-system-watcher)
5. [Wait For Changed Result](./documentation/structures/primitives/WaitForChangedResult.md#wait-for-changed-result)
6. [Drive Info Factory](./documentation/structures/primitives/DriveInfoFactory.md#drive-info-factory)
7. [Drive Info](./documentation/structures/primitives/DriveInfo.md#drive-info)
8. [File System Info](./documentation/structures/primitives/FileSystemInfo.md#file-system-info)
9. [Directory Info Factory](./documentation/structures/primitives/DirectoryInfoFactory.md#directory-info-factory)
10. [Directory Info](./documentation/structures/primitives/DirectoryInfo.md#directory-info)
11. [File Info Factory](./documentation/structures/primitives/FileInfoFactory.md#file-info-factory)
12. [File Info](./documentation/structures/primitives/FileInfo.md#file-info)
13. [Drives](./documentation/structures/primitives/Drives.md#drives)
14. [Directory](./documentation/structures/primitives/Directory.md#directory)
15. [File](./documentation/structures/primitives/File.md#file)
    


<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
    