# Progress Tracker — Teeny Titans 2 64-bit Recompilation

## Phase 1: Decompilation ?
- [x] APK extracted (apktool 2.9.3)
- [x] Java source decompiled (jadx 1.5.1)
- [x] Unity project reconstructed (AssetRipper 2.0.0) — Unity 2017.2.0f3
- [x] Managed C# decompiled (ILSpy) — Assembly-CSharp.dll, Assembly-CSharp-firstpass.dll
- [x] Native libs extracted (armeabi-v7a, x86)

## Phase 2: Unity 2021.3 Upgrade ?
- [x] Project opened in Unity 2021.3.45f1
- [x] Removed duplicate Newtonsoft.Json.dll
- [x] Removed conflicting IAP plugin DLLs (Purchasing.Common, Security, Stores, Apple, ChannelPurchase, FacebookStore, UnityStore, winrt)
- [x] Removed obsolete demo code (UnityStandardAssets, IAPDemo, AppStoresSupport, CharacterMotor, jMobileJoystick, FixGUIText, SetArabicTextExample)
- [x] Fixed IAPStore IStoreListener (both obsolete + new OnInitializeFailed)
- [x] Fixed __ldftn delegate artifacts (DOTween.To calls)
- [x] Fixed explicit accessor calls (OnlineCheck, PhotonNetwork, Time.timeScale)
- [x] Fixed unsafe-in-iterators (PortraitSwitcher, RiddlerShopController, TT2NetManager)
- [x] Fixed TT2NetNetworkDiscovery (stubbed for compilation)
- [x] Removed decompiled TMPro (conflict with package)
- [x] Added csc.rsp (-unsafe)
- [x] **0 compile errors** achieved

## Phase 3: 64-bit Android Build ??
- [x] Android SDK/NDK installed via Unity Hub
- [x] JDK 11 installed (Temurin)
- [x] BuildScript.BuildAndroid64 configured (IL2CPP, ARM64 + x86_64)
- [~] APK build configured (IL2CPP, ARM64 + x86_64); build attempted but hit Unity serialization-depth warnings on AssetRipper-exported data. Compile: 0 errors. Runtime build is the next task.
- [ ] Verify APK installs on 64-bit device/emulator

## Phase 4: GitHub Repository ??
- [x] Local repo initialized
- [x] Decompiled source + Unity project (source-level) committed
- [ ] Push to GitHub
- [ ] Add CI/build workflow

## Known limitations
- Binary game assets (textures, meshes, audio, scenes content) are not stored in git (size). Regenerate via AssetRipper from original APK.
- TT2NetNetworkDiscovery stubbed (multiplayer LAN discovery non-functional until reimplemented).
- Some demo/standard-asset code removed.

