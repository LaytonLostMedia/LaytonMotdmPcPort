# LaytonMotdmPcPort
This is a PC port of the DoCoMo mobile phone game "Professor Layton and the Mansion of the Deathly Mirror", also known as "レイトン教授と死鏡の館"

## Project architecture

### LaytonMotdm
The main entry point to the application.<br>
It provides a simple chapter selection and the screen to draw the game's content on.<br>
After setting up some chapter-specific information, it runs an asynchronous Task with the actual game logic in it.

### DocomoLayton
The game's actual logic.<br>
The code was decompiled from the .class Java files found in the game and adjusted to compile with C#. It was also annotated with attributes on classes, members, and methods to preserve the original, obfuscated names.<br>
The tools to decompile the .class Java files were FernFlower (IntelliJ's built-in java decompiler) and http://www.javadecompilers.com also set to FernFlower. Some classes decompiled with better code flow on the online resource than IntelliJ.

### DocomoSdk
Provides mostly stubs to references of the nttdocomo SDK in the game's logic.<br>
Actual implementations of SDK classes are, but not limited to:
- Graphics
- Image
- Font
- Canvas

Additionally, three helper classes were added to support access to various information, specific to DoCoMo mobile devices:
- AppInfo; provides access to the applications name, for example "deathmirror"
- Resources; provides access to the resources normally found in the application's .jar file
- ScratchPad; provides access to the application's persistent cache. Is used for meta and save data

### DocomoCsJavaBridge
Provides helper classes and logic to bridge the implementation differences and meta data from Java to C#.<br>
It contains the attributes used to annotate the C# classes, members, and methods to preserve the original, obfuscated names.<br>
It contains an event, that was injected in the game's logic to signal the LaytonMotdm wrapper application when a frame was done drawing.<br>
It contains some reimplementations of Java classes and types to replicate Java behaviour:
- Connector; provides access to javax.microedition.io.Connector and implementations for the protocols "scratchpad://" and "resource://"
- JavaString; provides access to native SJIS strings (as are default on DoCoMo mobile devices) and its various extensions, like Trim() (which trims whitespace differently than C#'s string.Trim())
- System; provides access to System.Out and was repurposed to use Serilog to print and log messages
