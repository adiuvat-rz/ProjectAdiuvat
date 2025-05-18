# XORPress & ProjectAdiuvat

A compression library and Windows Forms front-end to compress and decompress files using raw DEFLATE combined with a 4-byte XOR key.

---

## Table of Contents

* [Overview](#overview)
* [Features](#features)
* [Repository Structure](#repository-structure)
* [Prerequisites](#prerequisites)
* [Building the C++ Library (xorpress.dll)](#building-the-c-library-xorpressdll)
* [Using the Native Library in C# (ProjectAdiuvat)](#using-the-native-library-in-c-projectadiuvat)
* [Examples](#examples)
* [API Reference](#api-reference)
* [License](#license)
* [Acknowledgements](#acknowledgements)

---

## Overview

XORPress is a native C++ library (`xorpress.dll`) providing functions to:

1. Parse a comma-separated string of four hexadecimal bytes into a key
2. Compress data with raw DEFLATE, write a 4-byte original-size header, then apply an XOR to the first four compressed bytes
3. Decompress data by reversing the XOR and inflating the DEFLATE stream

To make it easy to use on Windows, we also provide a .NET Windows Forms application (**ProjectAdiuvat**) that wraps the native library via P/Invoke.

## Features

* **Custom XOR key**: Use any 4-byte hex key (e.g. `5A,2E,98,CE`).
* **Raw DEFLATE**: No zlib headers/trailers, minimizing overhead.
* **Header preservation**: Stores original size in first 4 bytes for precise decompression.
* **Batch processing**: Load multiple files, compress or decompress them all at once.
* **Timestamped logging**: Activity log with `yyyy-MM-dd HH:mm:ss` markers.
* **Progress bar**: Visual feedback in the Windows Forms UI.

## Repository Structure

The solution contains two projects within a single Visual Studio 2022 solution file (`ProjectAdiuvat.sln`), both configured for x64 builds:

```text
/ProjectAdiuvat.sln        # Visual Studio solution (x64)
│
├─ xorpress/              # Native C++ project (produces xorpress.dll)
│  ├─ Header Files/       # Precompiled headers and resource definitions (pch.h, resource.h)
│  ├─ Resource Files/     # Application resources (xorpress.rc)
│  └─ Source Files/       # DLL entry point and core implementation (dllmain.cpp, ParseKey.cpp, CompressFile.cpp, DecompressFile.cpp)
│
└─ ProjectAdiuvat/        # C# Windows Forms project
   ├─ Form1.cs            # UI logic and event handlers
   ├─ NativeMethods.cs    # P/Invoke declarations for xorpress.dll
   └─ ProjectAdiuvat.csproj
```

## Prerequisites

* **Windows 10/11 x64**
* **Visual Studio 2022** with **Desktop development with C++** and **.NET desktop development** workloads installed
* **zlib** (included as part of the project)
* **.NET Framework 4.7.2** (or later)

## Building the C++ Library (xorpress.dll)

1. Open `ProjectAdiuvat.sln` in Visual Studio 2022.
2. Set the solution configuration to **Release** and platform to **x64**.
3. In Solution Explorer, expand the **xorpress** project.
4. Build the **xorpress** project. This will produce `xorpress.dll` in the `xorpress\x64\Release` output folder.

## Using the Native Library in C# (ProjectAdiuvat)

1. Ensure `xorpress.dll` is copied into the `ProjectAdiuvat\bin\x64\Release` directory alongside the C# executable.
2. Open and build the **ProjectAdiuvat** project in Visual Studio 2022 (Release/x64).
3. Run the Windows Forms application. The UI includes:

   * Four textboxes (`xor1`–`xor4`) for the XOR key bytes
   * A textbox (`txtLevel`) for compression level (1–9)
   * Buttons to **Load .dec** or **Load .enc** files
   * **Compress** and **Decompress** buttons
   * A **ListBox** for activity logs and a **ProgressBar** to show progress

## Examples

```powershell
# Compress a single file via GUI:
# 1. Launch ProjectAdiuvat.exe
# 2. Enter key: 5A,2E,98,CE and level: 1 by default
# 3. Load .dec files and click "Compress".

# Programmatic call in C#:
int result = NativeMethods.CompressFilePathEx(
    "C:\input.dec",
    "C:\output.enc",
    "5A,2E,98,CE",
    6);
if (result != 0) Console.WriteLine($"Error code: {result}");
```

## API Reference

### C++ Exports (xorpress.dll)

| Function                                                                      | Description                                     |
| ----------------------------------------------------------------------------- | ----------------------------------------------- |
| `bool ParseKey(const std::wstring&, unsigned char out[4])`                    | Parses comma-separated hex string into 4 bytes. |
| `int CompressFilePathEx(const wchar_t*, const wchar_t*, const wchar_t*, int)` | Opens files and calls `CompressFileWithKey`.    |
| `int DecompressFilePathEx(const wchar_t*, const wchar_t*, const wchar_t*)`    | Opens files and calls `DecompressFileWithKey`.  |

### C# Wrappers (NativeMethods)

| Method                                                                      | Description                                  |
| --------------------------------------------------------------------------- | -------------------------------------------- |
| `int CompressFilePathEx(string source, string dest, string key, int level)` | P/Invoke for the native compress function.   |
| `int DecompressFilePathEx(string source, string dest, string key)`          | P/Invoke for the native decompress function. |

## License

This project is released under the **MIT License**. See [LICENSE](LICENSE) for details.

## Acknowledgements

* **zlib** for DEFLATE compression
* **RageZone.com** community for inspiration and feedback
* **adiuvat-rz** for initial development and community contributions
