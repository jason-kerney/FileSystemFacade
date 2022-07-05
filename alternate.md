
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

<!--
#user-content-istaticdrivereplacementbuilder
-->

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

<!--
#user-content-istaticdrivereplacement
-->

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
- [5.05 Replace](#user-content-directoryreplace)
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

<!--
#user-content-directory
-->

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

### Directory.Replace

```csharp
public static IDisposable Replace(IStaticDirectoryReplacement replacement);
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
    