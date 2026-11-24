using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildScript
{
    public static void BuildAndroid64()
    {
        UnityEditor.Android.AndroidExternalToolsSettings.jdkRootPath = @"C:\AIC\tools\jdk11\jdk-11.0.25+9";
        UnityEditor.Android.AndroidExternalToolsSettings.sdkRootPath = @"C:\Program Files\Unity\Hub\Editor\2021.3.45f1\Editor\Data\PlaybackEngines\AndroidPlayer\SDK";
        UnityEditor.Android.AndroidExternalToolsSettings.ndkRootPath = @"C:\Program Files\Unity\Hub\Editor\2021.3.45f1\Editor\Data\PlaybackEngines\AndroidPlayer\NDK";

        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64 | AndroidArchitecture.X86_64;
        PlayerSettings.bundleVersion = "1.1.4";
        PlayerSettings.productName = "Teeny Titans 2";

        BuildPlayerOptions opts = new BuildPlayerOptions();
        var scenes = EditorBuildSettings.scenes;
        var list = new System.Collections.Generic.List<string>();
        foreach (var s in scenes) if (s.enabled) list.Add(s.path);
        opts.scenes = list.ToArray();
        opts.locationPathName = "C:/AIC/work/build/TeenyTitans2_android64.apk";
        opts.target = BuildTarget.Android;
        opts.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(opts);
        if (report.summary.result == BuildResult.Succeeded)
            Debug.Log("BUILD SUCCEEDED: " + report.summary.totalSize + " bytes");
        else
            Debug.LogError("BUILD FAILED: " + report.summary.result);
        EditorApplication.Exit(report.summary.result == BuildResult.Succeeded ? 0 : 1);
    }
}

