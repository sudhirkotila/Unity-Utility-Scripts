/// <summary>
/// MenuShortcuts.cs
/// Developer Name : Sudhir Kotila
/// Email : sudhir.kotila@gmail.com
/// </summary>

using UnityEditor;
using UnityEngine;
using System.Collections;

public class MenuShortcuts : MonoBehaviour
{
    /*  To create a hotkey you can use the following special 
     * characters: % (ctrl on Windows, cmd on OS X), # (shift), & (alt), <b>_</b> (no key modifiers). 
     * For example to create a menu with hotkey shift-alt-g use "MyMenu/Do Something #&g". 
     * To create a menu with hotkey g and no key modifiers pressed use "MyMenu/Do Something _g".
     * Some special keyboard keys are supported as hotkeys, for example "#LEFT" would map to shift-left. 
     * The keys supported like this are: LEFT, RIGHT, UP, DOWN, F1 .. F12, HOME, END, PGUP, PGDN.
     * A hotkey text must be preceded with a space character ("MyMenu/Do_g" won't be interpreted as hotkey, while "MyMenu/Do _g" will).
     */

    /// <summary>
    /// Alt+Shift+A -> To Active or Deactive Objects
    /// </summary>
    [MenuItem("MyShortcuts/ActiveOrDeactive GameObject &#a")]
    static void ActiveOrDeactiveGameObject()
    {
        int noOfSelection = Selection.transforms.Length;
        if (noOfSelection > 0)
        {
            bool state = Selection.transforms[0].gameObject.activeSelf==true?false:true;
            foreach (Transform targetObj in Selection.transforms)
            {
                targetObj.gameObject.SetActive(state);
            }
        }
        else {
            print("No Selection");
        }
    }

    /// <summary>
    /// Alt+Shift+A -> To Create New GameObject Or Make New Child If Object Is Selected
    /// </summary>
	[MenuItem("MyShortcuts/CreateGameObjectOrChild &#n")]
    static void CreateChildOrNewGameObject()
    {
        int noOfSelection = Selection.transforms.Length;
        if (noOfSelection == 1)
        {
            GameObject newObj = new GameObject("Child");
            newObj.transform.parent = Selection.transforms[0];
            UnityEditor.Undo.RegisterCreatedObjectUndo(newObj, "Create Object");
            Selection.activeTransform = newObj.transform;
        }
        else
        {
            GameObject newObj = new GameObject("GameObject");
            UnityEditor.Undo.RegisterCreatedObjectUndo(newObj, "Create Object");
            Selection.activeTransform = newObj.transform;
        }
    }

    /// <summary>
    /// Set Position Vector To 0
    /// </summary>
	[MenuItem("MyShortcuts/Set Position To Zero  &#p")]
    static void SetPosition()
    {
        int noOfSelection = Selection.transforms.Length;
        if (noOfSelection > 0)
        {
            bool state = Selection.transforms[0].gameObject.activeSelf == true ? false : true;
            foreach (Transform targetObj in Selection.transforms)
            {
                //targetObj.position = Vector3.zero;
                targetObj.localPosition = Vector3.zero;
            }
        }
        else
        {
            print("No Selection");
        }
    }

    /// <summary>
    /// Set Position Vector To 0
    /// </summary>
	[MenuItem("MyShortcuts/Set Rotation To Zero  &#r")]
    static void SetRotation()
    {
        int noOfSelection = Selection.transforms.Length;
        if (noOfSelection > 0)
        {
            bool state = Selection.transforms[0].gameObject.activeSelf == true ? false : true;
            foreach (Transform targetObj in Selection.transforms)
            {
                targetObj.rotation = Quaternion.identity;
            }
        }
        else
        {
            print("No Selection");
        }
    }

    /// <summary>
    /// Set Scale Vector To 0
    /// </summary>
	[MenuItem("MyShortcuts/Set Scal To One  &#s")]
    static void SetScale()
    {
        int noOfSelection = Selection.transforms.Length;
        if (noOfSelection > 0)
        {
            bool state = Selection.transforms[0].gameObject.activeSelf == true ? false : true;
            foreach (Transform targetObj in Selection.transforms)
            {
                targetObj.localScale = Vector3.one;
            }
        }
        else
        {
            print("No Selection");
        }
    }

    /// <summary>
    /// Add Rigidbody 2d
    /// </summary>
	[MenuItem("MyShortcuts/Add2DBody  #r2")]
    static void AddRigidbody2D()
    {
        print("Body");
        int noOfSelection = Selection.transforms.Length;
        if (noOfSelection > 0)
        {
            bool state = Selection.transforms[0].gameObject.activeSelf == true ? false : true;
            foreach (Transform targetObj in Selection.transforms)
            {
                targetObj.gameObject.AddComponent<Rigidbody2D>();
                UnityEditor.Undo.RegisterCreatedObjectUndo(targetObj.gameObject, "UndoBody");
            }
        }
        else
        {
            print("No Selection");
        }
    }

    /// <summary>
    /// Add Rigidbody 3D
    /// </summary>
	[MenuItem("MyShortcuts/Add3DBody  &r3")]
    static void AddRigidbody3D()
    {
        print("Body");
        int noOfSelection = Selection.transforms.Length;
        if (noOfSelection > 0)
        {
            bool state = Selection.transforms[0].gameObject.activeSelf == true ? false : true;
            foreach (Transform targetObj in Selection.transforms)
            {
                targetObj.gameObject.AddComponent<Rigidbody>();
                UnityEditor.Undo.RegisterCreatedObjectUndo(targetObj.gameObject, "UndoBody");
            }
        }
        else
        {
            print("No Selection");
        }
    }
}
