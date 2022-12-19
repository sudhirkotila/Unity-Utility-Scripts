using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class KeyBoardEventHandler : MonoBehaviour
{
    [SerializeField]
    RectTransform _PanelRect;

    InputField mInputField;
    Rect mAreaCoveredByKeyboard;
    Vector2 mBasePos;
    bool mUpdateFlag;
    private void Awake()
    {
        mInputField = GetComponent<InputField>();
        mBasePos = _PanelRect.anchoredPosition;
    }

    private void OnEnable()
    {
        _PanelRect.anchoredPosition = mBasePos;
    }

    private void OnDisable()
    {

    }

    public void OnFocusGain()
    {
        mUpdateFlag = true;
        StopAllCoroutines();
        StartCoroutine(KeyboardUpdate());
    }

    public void OnFocusLost()
    {
        mUpdateFlag = false;
        StopAllCoroutines();
    }

    IEnumerator KeyboardUpdate()
    {
#if UNITY_ANDROID
        while (mUpdateFlag)
        {
            yield return new WaitUntil(() => TouchScreenKeyboard.visible && GetKeyboardSize() > 0);
            int currH = 0;
            int preH = GetKeyboardSize();


            while (currH != preH)
            {
                preH = currH;
                yield return new WaitForSeconds(0.2f); //TODO
                float keyboardArea = GetKeyboardSize();
                float percentage = (keyboardArea * 100f) / (float)Screen.height;
                keyboardArea = (1066f * percentage) / 100f; //1066 is a parent panel rect height

                // float offset = (mInputField.GetComponent<RectTransform>().position.y - (keyboardArea + 270));
                _PanelRect.anchoredPosition = new Vector2(mBasePos.x, mBasePos.y + (keyboardArea + 340f) / 2.0f);

                // if (offset < 0)
                // {
                //     _PanelRect.anchoredPosition = new Vector2(mBasePos.x, mBasePos.y - keyboardArea);
                // }
                currH = GetKeyboardSize();
            }

            yield return new WaitUntil(() => !TouchScreenKeyboard.visible);
            _PanelRect.anchoredPosition = mBasePos;

            yield return null;
        }

        yield break;
#else
    yield break;
#endif

    }

    public int GetKeyboardSize()
    {
#if UNITY_ANDROID
        using (AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");

            using (AndroidJavaObject Rct = new AndroidJavaObject("android.graphics.Rect"))
            {
                View.Call("getWindowVisibleDisplayFrame", Rct);

                return Screen.height - Rct.Call<int>("height");
            }
        }
#else
        return 0;
#endif
    }

    public int GetVisiableSize()
    {
#if UNITY_ANDROID
        using (AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");

            using (AndroidJavaObject Rct = new AndroidJavaObject("android.graphics.Rect"))
            {
                View.Call("getWindowVisibleDisplayFrame", Rct);

                return Rct.Call<int>("height");
            }
        }
#else
        return 0;
#endif
    }
}
