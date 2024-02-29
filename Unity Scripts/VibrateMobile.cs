using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices.ComTypes;

#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

public enum VibrateIntensity
{
    None,
    Low,
    Medium,
    High
}

public class VibrateMobile : MonoBehaviour
{
#if UNITY_IOS
    [DllImport ( "__Internal" )]
    private static extern bool _HasVibrator ();

    [DllImport ( "__Internal" )]
    private static extern void _Vibrate ();

    [DllImport ( "__Internal" )]
    private static extern void _VibratePop ();

    [DllImport ( "__Internal" )]
    private static extern void _VibratePeek ();

    [DllImport ( "__Internal" )]
    private static extern void _VibrateNope ();
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate()
    {
        if (GameProperties.isVibrationOn == 0) return;
        print("=== Normal Vibrate ===");
#if UNITY_ANDROID && !UNITY_EDITOR
print("AAAAAAAAAA");
            vibrator.Call("vibrate");
#elif UNITY_IOS && !UNITY_EDITOR
            _VibratePop ();
#else
        Handheld.Vibrate();
#endif
    }


    public static void Vibrate(long milliseconds)
    {
        if (GameProperties.isVibrationOn == 0) return;

#if UNITY_ANDROID && !UNITY_EDITOR
            vibrator.Call("vibrate", milliseconds);
#elif UNITY_IOS && !UNITY_EDITOR
            _VibratePop ();
#endif
    }

    public static void Vibrate(long[] pattern, int repeat)
    {
        if (GameProperties.isVibrationOn == 0) return;

        if (isAndroid())
            vibrator.Call("vibrate", pattern, repeat);
        else
            Handheld.Vibrate();
    }

    public static void Vibrate(VibrateIntensity intensity)
    {
        if (GameProperties.isVibrationOn == 0) return;

        print("<color=yellow>=== BUZZ ===</color>");
        switch (intensity)
        {
            case VibrateIntensity.None:
                Vibrate((long)0);
                break;
            case VibrateIntensity.Low:
                Vibrate((long)25);
                break;
            case VibrateIntensity.Medium:
                print("Medium - Buzzzzzzzzzzzzzzzzzzz");
                Vibrate((long)50);
                break;
            case VibrateIntensity.High:
                Vibrate((long)100);
                break;
            default:
                break;
        }

    }

    public static void Cancel()
    {
        if (isAndroid())
            vibrator.Call("cancel");
    }

    private static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
	return true;
#else
        return false;
#endif
    }
}