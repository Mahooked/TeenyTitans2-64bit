# Teeny Titans 2 — Decompiled & 64-bit Recompilation

Reverse-engineering project for **Teeny Titans 2 v1.1.4** (Grumpyface Studios), decompiled from the Amazon Appstore APK and restructured to be recompilable for **any platform, with 64-bit Android (arm64-v8a / x86_64) as the primary goal**.

## Source APK

- File: Teeny Titans 2 1.1.4.apk (Amazon build, 32-bit: armeabi-v7a + x86)
- Unity version: **2017.2.0f3** (Mono backend)
- Package: com.grumpyface.teenytitans2 (Amazon kiwi variant)

## What was done

- Full APK decompilation via pktool + jadx.
- Unity project reconstruction via **AssetRipper 2.0.0** (exported to Unity 2017.2 project).
- Managed C# decompilation via ILSpy (Assembly-CSharp.dll, Assembly-CSharp-firstpass.dll).
- Upgraded project to **Unity 2021.3.45f1** with Android build support.
- Fixed compile errors: duplicate assemblies, obsolete APIs (GUIText/GUITexture), unsafe-in-iterators, __ldftn delegate artifacts, IStoreListener interface changes, TMPro conflicts.
- Configured IL2CPP + ARM64/X86_64 build.
- Build verified: **0 compile errors**; APK build in progress.

## Repository layout

`
decompiled/
  csharp/              # decompiled game code (Assembly-CSharp)
  csharp-firstpass/    # firstpass / standard assets / plugins source
  native/              # extracted native libs (armeabi-v7a, x86)
  android/             # AndroidManifest.xml
unity/
  ProjectSettings/     # Unity project settings (target 2021.3)
  Packages/            # package manifest
  Assets/Scripts/      # game scripts (compilable)
  Assets/Editor/       # build scripts
  Assets/Plugins/      # third-party DLLs
  Assets/csc.rsp       # -unsafe
build/                 # (generated APKs, gitignored)
`

## Rebuilding for 64-bit Android

### Prerequisites

- Unity Hub + Unity **2021.3.45f1** with **Android Build Support** (SDK & NDK Tools, OpenJDK).
- JDK 11 (Temurin recommended).

### Steps

1. Open unity/ as a Unity project (Unity will upgrade from 2017.2 format).
2. Re-import game assets via AssetRipper from the original APK's ssets/bin/Data into this project (binary assets are not stored in git due to size).
3. Open File > Build Settings, select Android, set:
   - Scripting Backend: **IL2CPP**
   - Target Architectures: **ARM64 + x86_64**
4. Build, or run the automated build:
   `
   Unity.exe -batchmode -nographics -projectPath <path> -executeMethod BuildScript.BuildAndroid64 -quit
   `

### Building for other platforms

The Unity project can target any platform Unity supports (Windows, macOS, Linux, WebGL, iOS) via Build Settings, since all scripts are now platform-agnostic (IL2CPP).

## Progress tracking

See [PROGRESS.md](PROGRESS.md).

## Legal

This project is for educational/research purposes. Teeny Titans 2 is copyright Grumpyface Studios. Do not redistribute the original APK or assets commercially.
