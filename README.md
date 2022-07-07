
<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
# File System Facade #
#### A thin wrapper around .Net File Primitives to enable testing and refactoring. ####

## Table Of Contents ##

- [Section 1: Introduction](#user-content-introduction)
- [Section 2: Main File System Access](#user-content-main-file-system-access)
- [Section 3: Primitives](#user-content-primitives)
- [Section 4: Contributors ✨](#user-content-contributors-✨)

## Introduction ##

In my professional life I am often thrown into a code base that is badly in need of testing. One of the things that constantly throws people is interaction with the filesystem. How do you test code that creates, modifies or deletes actual files. This library is in response to those experiences.

My hope is that this library makes testing those things easier and thereby enable safe refactoring.
    

## Main File System Access ##

These are the the objects that are intended to be the main facade over the .Net File System.

### Main Access API Documentation

[Main Structures](./structures.md#file-system-facades-primary-file-system-access)

- [Atomic File System](./structures.md#user-content-atomic-file-system)
- [Atomic Actions](./structures.md#user-content-atomic-actions)
- [Atomic Replacement Builder](./structures.md#user-content-atomic-replacement-builder)
    

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
    

## Contributors ✨ ##

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/edf-re"><img src="https://avatars.githubusercontent.com/u/13739273?v=4?s=100" width="100px;" alt=""/><br /><sub><b>EDF Renewables</b></sub></a><br /><a href="#financial-edf-re" title="Financial">💵</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
    

<!-- GENERATED DOCUMENT! DO NOT EDIT! -->
    