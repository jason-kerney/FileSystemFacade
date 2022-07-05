<!--bl
(filemeta
    (title "Description"))
/bl-->

The main way to access file system objects is with short lived objects that live only for the length of a single method execution. If this is how you intend to access file system objects in .Net please read the documentation on the [Primary Way](./structures.md#file-system-facades-primary-file-system-access).

This documentation is about accessing these objects in a longer lived fashion. The factories that build these objects are static classes. Which means more care is needed when testing their interactions. It also means that fakes generated for testing may impact other parts of the system.