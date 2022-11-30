#if UNITY_ANDROID && UNITY_EDITOR

using UnityEditor;
using UnityEngine;
[InitializeOnLoad]
public class AndroidKeyStoreSetting
{
    static AndroidKeyStoreSetting()
    {
        PlayerSettings.keystorePass = "123456";
        PlayerSettings.keyaliasPass = "123456";
        PlayerSettings.Android.blitType = AndroidBlitType.Always;
    }
}
#endif