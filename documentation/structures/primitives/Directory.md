# Directory

## Summary

Exposes methods for creating, moving, and enumerating through directories and subdirectories without the need for an object representing those things.

This is a thin facade around [System.IO.Directory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-6.0).

```csharp
public interface IDirectory
```

## IDirectory

- [14.01 Create Directory](#user-content-idirectorycreatedirectory)
- [14.01 Delete](#user-content-idirectorydelete)
- [14.02 Enumerate Directories](#user-content-idirectoryenumeratedirectories)
- [14.03 Enumerate Files](#user-content-idirectoryenumeratefiles)
- [14.04 Enumerate File System Entries](#user-content-idirectoryenumeratefilesystementries)
- [14.05 Exists](#user-content-idirectoryexists)
- [14.06 Get Creation Time](#user-content-idirectorygetcreationtime)
- [14.07 Get Creation Time Utc](#user-content-idirectorygetcreationtimeutc)
- [14.08 Get Current Directory](#user-content-idirectorygetcurrentdirectory)
- [14.09 Get Directories](#user-content-idirectorygetdirectories)
- [14.10 Get Directory Root](#user-content-idirectorygetdirectoryroot)
- [14.11 Get Files](#user-content-idirectorygetfiles)
- [14.12 Get File System Entries](#user-content-idirectorygetfilesystementries)
- [14.13 Get Last Access Time](#user-content-idirectorygetlastaccesstime)
- [14.14 Get Last Access Time Utc](#user-content-idirectorygetlastaccesstimeutc)
- [14.15 Get Last Write Time](#user-content-idirectorygetlastwritetime)
- [14.16 Get Last Write Time Utc](#user-content-idirectorygetlastwritetimeutc)
- [14.17 Get Logical Drives](#user-content-idirectorygetlogicaldrives)
- [14.18 Get Parent](#user-content-idirectorygetparent)
- [14.19 Move](#user-content-idirectorymove)
- [14.20 Set Creation Time](#user-content-idirectorysetcreationtime)
- [14.21 Set Creation Time Utc](#user-content-idirectorysetcreationtimeutc)
- [14.22 Set Current Directory](#user-content-idirectorysetcurrentdirectory)
- [14.23 Set Last Access Time](#user-content-idirectorysetlastaccesstime)
- [14.24 Set Last Access Time Utc](#user-content-idirectorysetlastaccesstimeutc)
- [14.25 Set Last Write Time](#user-content-idirectorysetlastwritetime)
- [14.26 Set Last Write Time Utc](#user-content-idirectorysetlastwritetimeutc)
  
<!--
#user-content-idirectory
-->

## IDirectory.CreateDirectory

```csharp
IDirectoryInfo CreateDirectory(string path);
```

Creates all directories and subdirectories in the specified path unless they already exist.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The directory to create.

**returns** [IDirectoryInfo](./DirectoryInfo.md)

An object that represents the directory at the specified path. This object is returned regardless of whether a directory at the specified path already exists.

## IDirectory.Delete

| Signatures                                                                 |
|----------------------------------------------------------------------------|
| <a href="#user-content-idirectorydelete1">`void Delete(string);`</a>       |
| <a href="#user-content-idirectorydelete2">`void Delete(string, bool);`</a> |

---

<a id="user-content-idirectorydelete1"></a>
```csharp
void Delete(string path);
```

Deletes an empty directory from a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the empty directory to remove. This directory must be writable and empty.

---

<a id="user-content-idirectorydelete2"></a>
```csharp
void Delete(string path, bool recursive);
```

Deletes the specified directory and, if indicated, any subdirectories and files in the directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name of the directory to remove.

**recursive** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to remove directories, subdirectories, and files in path; otherwise, false.

## IDirectory.EnumerateDirectories

| Signatures                                                                                                                                  |
|---------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-idirectoryenumeratedirectories1">`IEnumerable<string> EnumerateDirectories(string);`</a>                             |
| <a href="#user-content-idirectoryenumeratedirectories2">`IEnumerable<string> EnumerateDirectories(string, string);`</a>                     |
| <a href="#user-content-idirectoryenumeratedirectories3">`IEnumerable<string> EnumerateDirectories(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-idirectoryenumeratedirectories4">`IEnumerable<string> EnumerateDirectories(string, string, SearchOption);`</a>       |

---

<a id="user-content-idirectoryenumeratedirectories1"></a>
```csharp
IEnumerable<string> EnumerateDirectories(string path);
```

Returns an enumerable collection of directory full names in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the directories in the directory specified by path.

---

<a id="user-content-idirectoryenumeratedirectories2"></a>
```csharp
IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
```

Returns an enumerable collection of directory full names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the directories in the directory specified by path and that match the specified search pattern.

---

<a id="user-content-idirectoryenumeratedirectories3"></a>
```csharp
IEnumerable<string> EnumerateDirectories(string path, string searchPattern,  System.IO.EnumerationOptions enumerationOptions);
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

<a id="user-content-idirectoryenumeratedirectories4"></a>
```csharp
IEnumerable<string> EnumerateDirectories(string path, string searchPattern, System.IO.SearchOption searchOption);
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

## IDirectory.EnumerateFiles

| Signatures                                                                                                                       |
|----------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-idirectoryenumeratefiles1">`IEnumerable<string> EnumerateFiles(string, string, SearchOption);`</a>        |
| <a href="#user-content-idirectoryenumeratefiles2">`IEnumerable<string> EnumerateFiles(string, string, EnumerationOptions); `</a> |
| <a href="#user-content-idirectoryenumeratefiles3">`IEnumerable<string> EnumerateFiles(string);`</a>                              |
| <a href="#user-content-idirectoryenumeratefiles4">`IEnumerable<string> EnumerateFiles(path, string);`</a>                        |

---

<a id="user-content-idirectoryenumeratefiles1"></a>
```csharp
IEnumerable<string> EnumerateFiles(string path, string searchPattern, System.IO.SearchOption searchOption);
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

<a id="user-content-idirectoryenumeratefiles2"></a>
```csharp
IEnumerable<string> EnumerateFiles(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
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

<a id="user-content-idirectoryenumeratefiles3"></a>
```csharp
IEnumerable<string> EnumerateFiles(string path);
```

Returns an enumerable collection of full file names in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the files in the directory specified by path.

---

<a id="user-content-idirectoryenumeratefiles4"></a>
```csharp
IEnumerable<string> EnumerateFiles(string path, string searchPattern);
```

Returns an enumerable collection of full file names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern.

## IDirectory.EnumerateFileSystemEntries

| Signatures                                                                                                                                              |
|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-idirectoryenumeratefilesystementries1">`IEnumerable<string> EnumerateFileSystemEntries(string);`</a>                             |
| <a href="#user-content-idirectoryenumeratefilesystementries2">`IEnumerable<string> EnumerateFileSystemEntries(string, string);`</a>                     |
| <a href="#user-content-idirectoryenumeratefilesystementries3">`IEnumerable<string> EnumerateFileSystemEntries(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-idirectoryenumeratefilesystementries4">`IEnumerable<string> EnumerateFileSystemEntries(string, string, SearchOption);`</a>       |

---

<a id="user-content-idirectoryenumeratefilesystementries1"></a>
```csharp
IEnumerable<string> EnumerateFileSystemEntries(string path);
```

Returns an enumerable collection of file names and directory names in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of file-system entries in the directory specified by path.

---

<a id="user-content-idirectoryenumeratefilesystementries2"></a>
```csharp
IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
```

Returns an enumerable collection of file names and directory names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern.

---

<a id="user-content-idirectoryenumeratefilesystementries3"></a>
```csharp
IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
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

<a id="user-content-idirectoryenumeratefilesystementries4"></a>
```csharp
IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, System.IO.SearchOption searchOption);
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

## IDirectory.Exists

```csharp
bool Exists(string? path);
```

Determines whether the given path refers to an existing directory on disk.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to test.

**returns** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true if path refers to an existing directory; false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.

## IDirectory.GetCreationTime

```csharp
DateTime GetCreationTime(string path);
```

Gets the creation date and time of a directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the directory.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A structure that is set to the creation date and time for the specified directory. This value is expressed in local time.

## IDirectory.GetCreationTimeUtc

```csharp
DateTime GetCreationTimeUtc(string path);
```

Gets the creation date and time, in Coordinated Universal Time (UTC) format, of a directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the directory.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A structure that is set to the creation date and time for the specified directory. This value is expressed in UTC time.

## IDirectory.GetCurrentDirectory

```csharp
string GetCurrentDirectory();
```

Gets the current working directory of the application.

**returns** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

A string that contains the absolute path of the current working directory, and does not end with a backslash (\).

## IDirectory.GetDirectories

| Signatures                                                                                                           |
|----------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-idirectorygetdirectories1">`string[] GetDirectories(string, string, SearchOption);`</a>       |
| <a href="#user-content-idirectorygetdirectories2">`string[] GetDirectories(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-idirectorygetdirectories3">`string[] GetDirectories(string);`</a>                             |
| <a href="#user-content-idirectorygetdirectories4">`string[] GetDirectories(string, string);`</a>                     |


---

<a id="user-content-idirectorygetdirectories1"></a>
```csharp
string[] GetDirectories(string path, string searchPattern, System.IO.SearchOption searchOption);
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

<a id="user-content-idirectorygetdirectories2"></a>
```csharp
string[] GetDirectories(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
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

<a id="user-content-idirectorygetdirectories3"></a>
```csharp
string[] GetDirectories(string path);
```

Returns the names of subdirectories (including their paths) in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) of subdirectories in the specified path, or an empty array if no directories are found.

---

<a id="user-content-idirectorygetdirectories4"></a>
```csharp
string[] GetDirectories(string path, string searchPattern);
```

Returns the names of subdirectories (including their paths) that match the specified search pattern in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of subdirectories in path. This parameter can contain a combination of valid literal and wildcard characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) of the subdirectories that match the search pattern in the specified directory, or an empty array if no directories are found.

## IDirectory.GetDirectoryRoot

```csharp
string GetDirectoryRoot(string path);
```

Returns the volume information, root information, or both for the specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of a file or directory.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

A string that contains the volume information, root information, or both for the specified path.

## IDirectory.GetFiles

| Signatures                                                                                               |
|----------------------------------------------------------------------------------------------------------|
| <a href="#user-content-idirectorygetfiles1">`string[] GetFiles(string);`</a>                             |
| <a href="#user-content-idirectorygetfiles2">`string[] GetFiles(string, string);`</a>                     |
| <a href="#user-content-idirectorygetfiles3">`string[] GetFiles(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-idirectorygetfiles4">`string[] GetFiles(string, string, SearchOption);`</a>       |

---

<a id="user-content-idirectorygetfiles1"></a>
```csharp
string[] GetFiles(string path);
```

Returns the names of files (including their paths) in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) for the files in the specified directory, or an empty array if no files are found.

---

<a id="user-content-idirectorygetfiles2"></a>
```csharp
string[] GetFiles(string path, string searchPattern);
```

Returns the names of files (including their paths) that match the specified search pattern in the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the full names (including paths) for the files in the specified directory that match the specified search pattern, or an empty array if no files are found.

---

<a id="user-content-idirectorygetfiles3"></a>
```csharp
string[] GetFiles(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
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

<a id="user-content-idirectorygetfiles4"></a>
```csharp
string[] GetFiles(string path, string searchPattern, System.IO.SearchOption searchOption);
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

## IDirectory.GetFileSystemEntries

| Signatures                                                                                                                       |
|----------------------------------------------------------------------------------------------------------------------------------|
| <a href="#user-content-idirectorygetfilesystementries1">`string[] GetFileSystemEntries(string);`</a>                             |
| <a href="#user-content-idirectorygetfilesystementries2">`string[] GetFileSystemEntries(string, string);`</a>                     |
| <a href="#user-content-idirectorygetfilesystementries3">`string[] GetFileSystemEntries(string, string, EnumerationOptions);`</a> |
| <a href="#user-content-idirectorygetfilesystementries4">`string[] GetFileSystemEntries(string, string, SearchOption);`</a>       |

---

<a id="user-content-idirectorygetfilesystementries1"></a>
```csharp
string[] GetFileSystemEntries(string path);
```

Returns the names of all files and subdirectories in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of the names of files and subdirectories in the specified directory, or an empty array if no files or subdirectories are found.

---

<a id="user-content-idirectorygetfilesystementries2"></a>
```csharp
string[] GetFileSystemEntries(string path, string searchPattern);
```

Returns an array of file names and directory names that match a search pattern in a specified path.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of file and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.

---

<a id="user-content-idirectorygetfilesystementries3"></a>
```csharp
string[] GetFileSystemEntries(string path, string searchPattern, System.IO.EnumerationOptions enumerationOptions);
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

<a id="user-content-idirectorygetfilesystementries4"></a>
```csharp
string[] GetFileSystemEntries(string path, string searchPattern, System.IO.SearchOption searchOption);
```

Returns an array of all the file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The relative or absolute path to the directory to search. This string is not case-sensitive.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files and directories in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories. The default value is TopDirectoryOnly.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

An array of file the file names and directory names that match the specified search criteria, or an empty array if no files or directories are found.

## IDirectory.GetLastAccessTime

```csharp
DateTime GetLastAccessTime(string path);
```

public static DateTime GetLastAccessTime (string path);

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A structure that is set to the date and time the specified file or directory was last accessed. This value is expressed in local time.

## IDirectory.GetLastAccessTimeUtc

```csharp
DateTime GetLastAccessTimeUtc(string path);
```

Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain access date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A structure that is set to the date and time the specified file or directory was last accessed. This value is expressed in UTC time.

## IDirectory.GetLastWriteTime

```csharp
DateTime GetLastWriteTime(string path);
```

Returns the date and time the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain modification date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A structure that is set to the date and time the specified file or directory was last written to. This value is expressed in local time.

## IDirectory.GetLastWriteTimeUtc

```csharp
DateTime GetLastWriteTimeUtc(string path);
```

Returns the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to obtain modification date and time information.

**returns** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

A structure that is set to the date and time the specified file or directory was last written to. This value is expressed in UTC time.

## IDirectory.GetLogicalDrives

```csharp
string[] GetLogicalDrives();
```

Retrieves the names of the logical drives on this computer in the form "<drive letter>:\".

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)\>

The logical drives on this computer.

## IDirectory.GetParent

```csharp
IDirectoryInfo? GetParent(string path);
```

Retrieves the parent directory of the specified path, including both absolute and relative paths.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path for which to retrieve the parent directory.

**returns** [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

The parent directory, or null if path is the root directory, including the root of a UNC server or share name.

## IDirectory.Move

```csharp
void Move(string sourceDirName, string destDirName);
```

Moves a file or a directory and its contents to a new location.

**sourceDirName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the file or directory to move.

**destDirName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to the new location for sourceDirName or its contents. If sourceDirName is a file, then destDirName must also be a file name.

## IDirectory.SetCreationTime

```csharp
void SetCreationTime(string path, DateTime creationTime);
```

Sets the creation date and time for the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the creation date and time information.

**creationTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The date and time the file or directory was last written to. This value is expressed in local time.

## IDirectory.SetCreationTimeUtc

```csharp
void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
```

Sets the creation date and time, in Coordinated Universal Time (UTC) format, for the specified file or directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the creation date and time information.

**creationTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The date and time the directory or file was created. This value is expressed in local time.

## IDirectory.SetCurrentDirectory

```csharp
void SetCurrentDirectory(string path);
```

Sets the application's current working directory to the specified directory.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path to which the current working directory is set.

## IDirectory.SetLastAccessTime

```csharp
void SetLastAccessTime(string path, DateTime lastAccessTime);
```

Sets the date and time the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the access date and time information.

**lastAccessTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

An object that contains the value to set for the access date and time of path. This value is expressed in local time.

## IDirectory.SetLastAccessTimeUtc

```csharp
void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
```

Sets the date and time, in Coordinated Universal Time (UTC) format, that the specified file or directory was last accessed.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The file or directory for which to set the access date and time information.

**lastAccessTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

An object that contains the value to set for the access date and time of path. This value is expressed in UTC time.

## IDirectory.SetLastWriteTime

```csharp
void SetLastWriteTime(string path, DateTime lastWriteTime);
```

Sets the date and time a directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the directory.

**lastWriteTime** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The date and time the directory was last written to. This value is expressed in local time.

## IDirectory.SetLastWriteTimeUtc

```csharp
void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
```

Sets the date and time, in Coordinated Universal Time (UTC) format, that a directory was last written to.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The path of the directory.

**lastWriteTimeUtc** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0)

The date and time the directory was last written to. This value is expressed in UTC time.