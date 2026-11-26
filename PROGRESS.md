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
- [x] APK build: **SUCCESS** — IL2CPP, arm64-v8a + x86_64, 418 MB. Verified lib/arm64-v8a and lib/x86_64 present.
- [x] APK installed and launched on a 64-bit Android device (package: com.GrumpyfaceStudios.TeenyTitans2). App runs (network config fetch fails offline, expected).

## Phase 4: GitHub Repository ??
- [x] Local repo initialized
- [x] Decompiled source + Unity project (source-level) committed
- [ ] Push to GitHub
- [ ] Add CI/build workflow

## Known limitations
- Binary game assets (textures, meshes, audio, scenes content) are not stored in git (size). Regenerate via AssetRipper from original APK.
- TT2NetNetworkDiscovery stubbed (multiplayer LAN discovery non-functional until reimplemented).
- Some demo/standard-asset code removed.






## Phase 5: Runtime playability (in progress)
- [x] Main menu now renders (textures visible)
- [x] NullReferenceExceptions eliminated (was 15+, now 0)
- [x] Guarded: CityController, CityEntity, CityEntityNPC, CityEntityBuilding, CityCharacter, CurrencyGUI, WalletGUI, Communicator, CityShopSign, DailyMissionBoard, LocalizedText, DailyMissionManager, LocalizedSpriteToText, SimpleTextButton, GameLinkPopupDialog, InitController (ToS auto-accept), NewGameIntroController
- [x] Fixed TMP Settings script GUID (was broken)
- [x] Fixed PlayerReward serialization (eggRewards NonSerialized)
- [x] Fixed CheckURLExists (iOS-only native call guarded for Android)
- [ ] Remaining: 3 missing native SDK classes (Adobe Analytics, comScore, EasyMovieTexture) — caught exceptions, non-blocking
- [ ] Black screen persists after init completes — investigating scene/camera activation
