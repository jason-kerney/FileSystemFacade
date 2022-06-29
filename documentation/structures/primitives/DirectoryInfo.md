<!--bl
(filemeta
    (title "Directory Info"))
/bl-->

### Summary

Exposes methods for creating, moving, and enumerating through directories and subdirectories.

This is a thin facade around [System.IO.DirectoryInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=net-6.0)

```csharp
public interface IDirectoryInfo : IFileSystemInfo
```

### IDirectoryInfo

- [13.01 Parent](#user-content-idirectoryinfoparent)
- [13.02 Root](#user-content-idirectoryinforoot)
- [13.03 Create](#user-content-idirectoryinfocreate)
- [13.04 Create Subdirectory](#user-content-idirectoryinfocreatesubdirectory)
- [13.05 Delete](#user-content-idirectoryinfodelete)
- [13.06 Enumerate Directories](#user-content-idirectoryinfoenumeratedirectories)
- [13.07 Enumerate Files](#user-content-idirectoryinfoenumeratefiles)
- [13.08 Enumerate File System Infos](#user-content-idirectoryinfoenumeratefilesysteminfos)
- [13.09 Get Directories](#user-content-idirectoryinfogetdirectories)
- [13.10 Get Files](#user-content-idirectoryinfogetfiles)
- [13.11 Get File System Infos](#user-content-idirectoryinfogetfilesysteminfos)
- [13.12 Move To](#user-content-idirectoryinfomoveto)

### IDirectoryInfo.Parent

```csharp
IDirectoryInfo? Parent { get; }
```

Gets the parent directory of a specified subdirectory.

**returns**  [Nullable](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

The parent directory of a specified subdirectory.

### IDirectoryInfo.Root

```csharp
IDirectoryInfo Root { get; }
```

Gets the root portion of the directory.

**returns** [IDirectoryInfo](./DirectoryInfo.md)

The root portion of the directory.

### IDirectoryInfo.Create

```csharp
void Create();
```

Creates a directory.

### IDirectoryInfo.CreateSubdirectory

```csharp
IDirectoryInfo CreateSubdirectory(string path);
```

Creates a subdirectory or subdirectories on the specified path. The specified path can be relative to this instance of the DirectoryInfo class.

**path** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The specified path. This cannot be a different disk volume or Universal Naming Convention (UNC) name.

**returns** [IDirectoryInfo](./DirectoryInfo.md)

The last directory specified in path.

### IDirectoryInfo.Delete

```csharp
void Delete(bool recursive);
```

Deletes this instance of a DirectoryInfo, specifying whether to delete subdirectories and files.

**recursive** [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean?view=net-6.0)

true to delete this directory, its subdirectories, and all files; otherwise, false.

### IDirectoryInfo.EnumerateDirectories

| Signatures                                                                                                                                       |
|--------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href='#user-content-idirectoryinfoenumeratedirectories1'>`IEnumerable<IDirectoryInfo> EnumerateDirectories(string, SearchOption);`</a>        |
| <a href='#user-content-idirectoryinfoenumeratedirectories2'>`IEnumerable<IDirectoryInfo> EnumerateDirectories(string,  EnumerationOptions);`</a> |
| <a href='#user-content-idirectoryinfoenumeratedirectories3'>`IEnumerable<IDirectoryInfo> EnumerateDirectories();`</a>                            |
| <a href='#user-content-idirectoryinfoenumeratedirectories4'>`IEnumerable<IDirectoryInfo> EnumerateDirectories(string);`</a>                      |

---

<a id='user-content-idirectoryinfoenumeratedirectories1'></a>
```csharp
IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, System.IO.SearchOption searchOption);
```

Returns an enumerable collection of directory information that matches a specified search pattern and search subdirectory option.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An enumerable collection of directories that matches searchPattern and searchOption.

---

<a id='user-content-idirectoryinfoenumeratedirectories2'></a>
```csharp
IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern,  System.IO.EnumerationOptions enumerationOptions);
```

Returns an enumerable collection of directory information that matches the specified search pattern and enumeration options.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An enumerable collection of directories that matches searchPattern and enumerationOptions.

---

<a id='user-content-idirectoryinfoenumeratedirectories3'></a>
```csharp
IEnumerable<IDirectoryInfo> EnumerateDirectories();
```

Returns an enumerable collection of directory information in the current directory.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An enumerable collection of directories in the current directory.

---

<a id='user-content-idirectoryinfoenumeratedirectories4'></a>
```csharp
IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern);
```

Returns an enumerable collection of directory information that matches a specified search pattern.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An enumerable collection of directories that matches searchPattern.

### IDirectoryInfo.EnumerateFiles

| Signatures                                                                                                                     |
|--------------------------------------------------------------------------------------------------------------------------------|
| <a href='#user-content-idirectoryinfoenumeratefiles1'>`IEnumerable<IFileInfo> EnumerateFiles();`</a>                           |
| <a href='#user-content-idirectoryinfoenumeratefiles2'>`IEnumerable<IFileInfo> EnumerateFiles(string);`</a>                     |
| <a href='#user-content-idirectoryinfoenumeratefiles3'>`IEnumerable<IFileInfo> EnumerateFiles(string, EnumerationOptions);`</a> |

---

<a id='user-content-idirectoryinfoenumeratefiles1'></a>
```csharp
IEnumerable<IFileInfo> EnumerateFiles();
```

Returns an enumerable collection of file information in the current directory.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileInfo](./FileInfo.md)\>

An enumerable collection of the files in the current directory.

---

<a id='user-content-idirectoryinfoenumeratefiles2'></a>
```csharp
IEnumerable<IFileInfo> EnumerateFiles(string searchPattern);
```

Returns an enumerable collection of file information that matches a search pattern.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileInfo](./FileInfo.md)\>

An enumerable collection of files that matches searchPattern.

---

<a id='user-content-idirectoryinfoenumeratefiles3'></a>
```csharp
IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns an enumerable collection of file information that matches the specified search pattern and enumeration options.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileInfo](./FileInfo.md)\>

An enumerable collection of files that matches searchPattern and enumerationOptions.

---

<a id='user-content-idirectoryinfoenumeratefiles4'></a>
```csharp
IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, System.IO.SearchOption searchOption);
```

Returns an enumerable collection of file information that matches a specified search pattern and search subdirectory option.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileInfo](./FileInfo.md)\>

An enumerable collection of files that matches searchPattern and searchOption.

### IDirectoryInfo.EnumerateFileSystemInfos

| Signatures                                                                                                                                              |
|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| <a href='#user-content-idirectoryinfoenumeratefilesysteminfos1'>`IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string, SearchOption);`</a>      |
| <a href='#user-content-idirectoryinfoenumeratefilesysteminfos2'>`IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos();`</a>                          |
| <a href='#user-content-idirectoryinfoenumeratefilesysteminfos3'>`IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string);`</a>                    |
| <a href='user-content-idirectoryinfoenumeratefilesysteminfos4'>`IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string, EnumerationOptions);`</a> |

---

<a id='user-content-idirectoryinfoenumeratefilesysteminfos1'></a>
```csharp
IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption);
```

Returns an enumerable collection of file system information that matches a specified search pattern and search subdirectory option.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An enumerable collection of file system information objects that matches searchPattern and searchOption.

---

<a id='user-content-idirectoryinfoenumeratefilesysteminfos2'></a>
```csharp
IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos();
```

Returns an enumerable collection of file system information in the current directory.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An enumerable collection of file system information in the current directory.

---

<a id='user-content-idirectoryinfoenumeratefilesysteminfos3'></a>
```csharp
IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern);
```

Returns an enumerable collection of file system information that matches a specified search pattern.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An enumerable collection of file system information objects that matches searchPattern.

---

<a id='user-content-idirectoryinfoenumeratefilesysteminfos4'></a>
```csharp
IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns an enumerable collection of file system information that matches the specified search pattern and enumeration options.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An enumerable collection of file system information objects that matches searchPattern and enumerationOptions.

### IDirectoryInfo.GetDirectories

| Signatures                                                                                                               |
|--------------------------------------------------------------------------------------------------------------------------|
| <a href='#user-content-idirectoryinfogetdirectories1'>`IDirectoryInfo[] GetDirectories();`</a>                           |
| <a href='#user-content-idirectoryinfogetdirectories2'>`IDirectoryInfo[] GetDirectories(string, EnumerationOptions);`</a> |
| <a href='#user-content-idirectoryinfogetdirectories3'>`IDirectoryInfo[] GetDirectories(string, SearchOption);`</a>       |

---

Returns the subdirectories of the current directory.

<a id='user-content-idirectoryinfogetdirectories1'></a>
```csharp
IDirectoryInfo[] GetDirectories();
```

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An array of IDirectoryInfo objects.

---

<a id='user-content-idirectoryinfogetdirectories1'></a>
```csharp
IDirectoryInfo[] GetDirectories(string searchPattern);
```

Returns an array of directories in the current IDirectoryInfo matching the given search criteria.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An array of type IDirectoryInfo matching searchPattern.

---

<a id='user-content-idirectoryinfogetdirectories2'></a>
```csharp
IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns an array of directories in the current IDirectoryInfo matching the specified search pattern and enumeration options.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An array of type IDirectoryInfo matching searchPattern and enumerationOptions.

---

<a id='user-content-idirectoryinfogetdirectories3'></a>
```csharp
IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.SearchOption searchOption);
```

Returns an array of directories in the current IDirectoryInfo matching the given search criteria and using a value to determine whether to search subdirectories.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IDirectoryInfo](./DirectoryInfo.md)\>

An array of type IDirectoryInfo matching searchPattern and enumerationOptions.

### IDirectoryInfo.GetFiles

| Signatures                                                                                              |
|---------------------------------------------------------------------------------------------------------|
| <a href='#user-content-idirectoryinfogetfiles1'>`IFileInfo[] GetFiles(string, EnumerationOptions);`</a> |
| <a href='#user-content-idirectoryinfogetfiles2'>`IFileInfo[] GetFiles(string, SearchOption);`</a>       |
| <a href='#user-content-idirectoryinfogetfiles3'>`IFileInfo[] GetFiles();`</a>                           |
| <a href='#user-content-idirectoryinfogetfiles4'>`IFileInfo[] GetFiles(string);`</a>                     |

---

<a id='user-content-idirectoryinfogetfiles1'></a>
```csharp
IFileInfo[] GetFiles(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Returns a file list from the current directory matching the specified search pattern and enumeration options.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileInfo](./FileInfo.md)\> 

An array of IFileInfo objects that match searchPattern and enumerationOptions.

---

<a id='user-content-idirectoryinfogetfiles2'></a>
```csharp
IFileInfo[] GetFiles(string searchPattern, System.IO.SearchOption searchOption);
```

Returns a file list from the current directory matching the given search pattern and using a value to determine whether to search subdirectories.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileInfo](./FileInfo.md)\>

An array of type IFileInfo.

---

<a id='user-content-idirectoryinfogetfiles3'></a>
```csharp
IFileInfo[] GetFiles();
```

Returns a file list from the current directory.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileInfo](./FileInfo.md)\>

An array of type IFileInfo.

---

<a id='user-content-idirectoryinfogetfiles4'></a>
```csharp
IFileInfo[] GetFiles(string searchPattern);
```

Returns a file list from the current directory matching the given search pattern.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileInfo](./FileInfo.md)\>

An array of type IFileInfo.

### IDirectoryInfo.GetFileSystemInfos

| Signatures                                                                                                                        |
|-----------------------------------------------------------------------------------------------------------------------------------|
| <a href='#user-content-idirectoryinfogetfilesysteminfos1'>`IFileSystemInfo[] GetFileSystemInfos();`</a>                           |
| <a href='#user-content-idirectoryinfogetfilesysteminfos2'>`IFileSystemInfo[] GetFileSystemInfos(string);`</a>                     |
| <a href='#user-content-idirectoryinfogetfilesysteminfos3'>`IFileSystemInfo[] GetFileSystemInfos(string, EnumerationOptions);`</a> |
| <a href='#user-content-idirectoryinfogetfilesysteminfos4'>`IFileSystemInfo[] GetFileSystemInfos(string, SearchOption);`</a>       |


---

<a id='user-content-idirectoryinfogetfilesysteminfos1'></a>
```csharp
IFileSystemInfo[] GetFileSystemInfos();
```

Returns an array of IFileSystemInfo entries representing all the files and subdirectories in a directory.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An array of IFileSystemInfo entries.

---

<a id='user-content-idirectoryinfogetfilesysteminfos2'></a>
```csharp
IFileSystemInfo[] GetFileSystemInfos(string searchPattern);
```

Retrieves an array of IFileSystemInfo objects representing the files and subdirectories that match the specified search criteria.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories and files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An array of IFileSystemInfo objects matching the search criteria.

---

<a id='user-content-idirectoryinfogetfilesysteminfos3'></a>
```csharp
IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.EnumerationOptions enumerationOptions);
```

Retrieves an array of IFileSystemInfo objects representing the files and subdirectories that match the specified search pattern and enumeration options.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories and files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**enumerationOptions** [System.IO.EnumerationOptions](https://docs.microsoft.com/en-us/dotnet/api/system.io.enumerationoptions?view=net-6.0)

An object that describes the search and enumeration configuration to use.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An array of IFileSystemInfo objects matching searchPattern and enumerationOptions.

---

<a id='user-content-idirectoryinfogetfilesysteminfos4'></a>
```csharp
IFileSystemInfo[] GetFileSystemInfos(string searchPattern, System.IO.SearchOption searchOption);
```

Retrieves an array of IFileSystemInfo objects that represent the files and subdirectories matching the specified search criteria.

**searchPattern** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The search string to match against the names of directories and files. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but it doesn't support regular expressions.

**searchOption** [System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/system.io.searchoption?view=net-6.0)

One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.

**returns** [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)\<[IFileSystemInfo](./FileSystemInfo.md)\>

An array of file system entries that match the search criteria.

### IDirectoryInfo.MoveTo

```csharp
void MoveTo(string destDirName);
```

Moves a DirectoryInfo instance and its contents to a new path.

**destDirName** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0)

The name and path to which to move this directory. The destination cannot be another disk volume or a directory with the identical name. It can be an existing directory to which you want to add this directory as a subdirectory.