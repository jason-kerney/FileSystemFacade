
<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
# File System Facade's Alternate File System Access #
#### A guide to the interfaces and objects that allow you to access the file system from a static class. ####

## Table Of Contents ##

- [Section 1: Description](#user-content-description)
- [Section 2: Drive](#user-content-drive)
- [Section 3: Static Drive Replacement](#user-content-static-drive-replacement)
- [Section 4: Directory](#user-content-directory)
- [Section 5: Static Directory Replacement](#user-content-static-directory-replacement)
- [Section 6: File](#user-content-file)
- [Section 7: Static File Replacement](#user-content-static-file-replacement)
- [Section 8: Primitives](#user-content-primitives)

## Description ##

The main way to access file system objects is with short lived objects that live only for the length of a single method execution. If this is how you intend to access file system objects in .Net please read the documentation on the [Primary Way](./structures.md).

This documentation is about accessing these objects in a longer lived fashion. The factories that build these objects are static classes. Which means more care is needed when testing their interactions. It also means that fakes generated for testing may impact other parts of the system.
    

## Drive ##

TBD
    

## Static Drive Replacement ##

TBD
    

## Directory ##

TBD
    

## Static Directory Replacement ##

TBD
    

## File ##

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
    