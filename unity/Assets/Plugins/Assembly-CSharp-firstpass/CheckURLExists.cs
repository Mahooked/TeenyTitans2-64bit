using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CheckURLExists
{
#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern bool _CheckURL(string url);
#endif

	public static bool CheckURL(string url)
	{
#if UNITY_IOS
		return _CheckURL(url);
#else
		return true;
#endif
	}

	public static bool AndroidAppInstalled(string bundleID)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		Debug.Log(" ********LaunchOtherApp ");
		AndroidJavaObject androidJavaObject3 = null;
		try
		{
			androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { bundleID });
		}
		catch (Exception ex)
		{
			Debug.Log("exception" + ex.Message);
		}
		if (androidJavaObject3 == null)
		{
			Debug.Log(bundleID + " dont got it");
			return false;
		}
		Debug.Log(bundleID + " got it");
		return true;
	}
}
