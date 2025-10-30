# LaytonMotdmPcPort
This is a PC port of the DoCoMo mobile phone game "Professor Layton and the Mansion of the Deathly Mirror", also known as "レイトン教授と死鏡の館".

## Project architecture

### DoCoMoPlayer
The main entry point to the player.<br>
It provides a simple chapter selection and the screen to draw the game's content on.<br>
After setting up some chapter-specific information, it runs an asynchronous Task with the actual game logic in it.

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
- Connector; provides access to javax.microedition.io.Connector and implementations for the protocols "scratchpad://" and "resource://"

### DocomoStarSdk
Same as [DocomoSdk](https://github.com/LaytonLostMedia/LaytonMotdmPcPort/blob/main/README.md#docomosdk), but for DoJa Star.

This SDK stub is not actively used in "Professor Layton and the Mansion of the Deathly Mirror" and is only here for more player and game support in general. 

### DocomoJavaSdk
Provides reimplementations to bridge the implementation differences from Java to C#:
- DataInputStream; provides access to Java's equivalent of "BinaryReader"
- DataOutputStream; provides access to Java's equivalent of "BinaryWriter"
- JavaString; provides access to native SJIS strings (as are default on DoCoMo mobile devices) and its various extensions, like Trim() (which trims whitespace differently than C#'s string.Trim())
- System; provides access to System.Out and was repurposed to use Serilog to print and log messages

### DocomoCsJavaBridge
Provides logic to offer meta data from Java to C#:
- Aspects; provides access to attributes used to annotate C# classes, members, and methods to preserve the original, obfuscated names
- EncodingProvider; provides global access to a pre-determined string encoding; used for string operations throughout the game and player logic to keep them consistent
- PathProvider; provides global access to standard paths used in Java and DoJa
- JamResource and AppInfo; provides logic to parse the DoJa .jam file and access its data in a type-safe manner respectively

### Apps
Contains apps that can be compiled and played by the player.<br>
Every app represents its game's actual logic.<br>
The code was decompiled from the .class Java files found in the game and adjusted to compile with C#. It was also annotated with attributes on classes, members, and methods to preserve the original, obfuscated names.<br>
The tools to decompile the .class Java files were FernFlower (IntelliJ's built-in java decompiler) and http://www.javadecompilers.com also set to FernFlower. Some classes decompiled with better code flow on the online resource than IntelliJ.
