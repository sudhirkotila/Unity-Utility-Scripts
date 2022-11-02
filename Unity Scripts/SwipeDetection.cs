using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 fp; // first finger position
    private Vector2 lp; // last finger position
    public RectTransform player; // Drag your player here
    private float hSwipeDist, vSwipeDist;
    Bounds CalculateBounds(RectTransform argTransform, float uiScaleFactor)
    {
        Bounds bounds = new Bounds(argTransform.position, new Vector3(argTransform.rect.width, argTransform.rect.height, 0.0f) * uiScaleFactor);
        return bounds;
    }

    void OnGUI()
    {
        CheckMouseAsTouch(Event.current.type, Input.mousePosition);
    }
    //Mouse Swipe Detection . . .
    void CheckMouseAsTouch(EventType touch, Vector3 currentPosition)
    {
        //began
        if (touch.ToString() == "mouseDown")
        {
            fp = new Vector2(currentPosition.x, currentPosition.y);
            lp = new Vector2(currentPosition.x, currentPosition.y);
        }

        if (!player.isMouseOverUI())
        {
            return;
        }

        //moved
        if (touch.ToString() == "mouseDrag")
        {
            lp = new Vector2(currentPosition.x, currentPosition.y);
        }

        //ended
        if (touch.ToString() == "mouseUp")
        {
            hSwipeDist = fp.x - lp.x;
            vSwipeDist = fp.y - lp.y;
            if (Mathf.Abs(hSwipeDist) > Mathf.Abs(vSwipeDist))
            {
                fp.y = Mathf.Clamp(0f, -90f, 90f);
                if ((fp.x - lp.x) > 30)
                { // left swipe
                  // player.Rotate(0, -90, 0);
                    print("Left Swipe Using Mouse...");
                }
                else if ((fp.x - lp.x) < -30)
                { // right swipe
                  // player.Rotate(0, 90, 0);
                    print("Right Swipe Using Mouse...");
                }
            }
            else
            {
                fp.x = Mathf.Clamp(-90f, 0f, 90f);
                if ((fp.y - lp.y) > 80)
                { // down swipe
                  // player.Rotate(0, -90, 0);
                    print("Down Swipe Using Mouse...");
                }
                else if ((fp.y - lp.y) < -80)
                { // Up swipe
                  // player.Rotate(0, 90, 0);
                    print("Up Swipe Using Mouse...");
                }
            }
            // fp.y = Mathf.Clamp(0f, -90f, 90f);
            // if ((fp.x - lp.x) > 30)
            // { // left swipe
            //     // player.Rotate(0, -90, 0);
            //     print("Left Swipe Using Mouse...");
            // }
            // else if ((fp.x - lp.x) < -30)
            // { // right swipe
            //     // player.Rotate(0, 90, 0);
            //     print("Right Swipe Using Mouse...");
            // }
            // else if ((fp.y - lp.y) > 80)
            // { // down swipe
            //     // player.Rotate(0, -90, 0);
            //     print("Down Swipe Using Mouse...");
            // }
            // else if ((fp.y - lp.y) < -80)
            // { // right swipe
            //     // player.Rotate(0, 90, 0);
            //     print("Up Swipe Using Mouse...");
            // }
        }
    }

    // Touch Swipe Detection . . .
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if ((fp.x - lp.x) > 80)
                { // left swipe
                    // player.Rotate(0, -90, 0);
                    print("Left Swipe Using Touch...");
                }
                else if ((fp.x - lp.x) < -80)
                { // right swipe
                    // player.Rotate(0, 90, 0);
                    print("Right Swipe Using Touch...");
                }
                else if ((fp.y - lp.y) > 80)
                { // left swipe
                    // player.Rotate(0, -90, 0);
                    print("Down Swipe Using Mouse...");
                }
                else if ((fp.y - lp.y) < -80)
                { // right swipe
                    // player.Rotate(0, 90, 0);
                    print("Up Swipe Using Mouse...");
                }
                // else if ((fp.y - lp.y) < -80)
                // { // up swipe
                //   // add your jumping code here
                // }
            }
        }
    }
}

namespace UnityEngine
{
    namespace UI
    {
        public static class ExtensionMethods
        {
            public static Rect GetGlobalPosition(this RectTransform rectTransform)
            {
                Vector3[] corners = new Vector3[4];
                rectTransform.GetWorldCorners(corners);
                return new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);
            }

            public static bool isMouseOverUI(this RectTransform rectTransform)
            {
                Rect position = rectTransform.GetGlobalPosition();
                return position.Contains(Input.mousePosition);
            }
        }
    }
}