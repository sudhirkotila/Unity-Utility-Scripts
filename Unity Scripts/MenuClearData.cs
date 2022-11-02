using UnityEngine;
using UnityEditor;

public class MenuItems
{
	[MenuItem ("MyShortCuts/Clear PlayerPrefs")]
	private static void NewMenuOption ()
	{
		PlayerPrefs.DeleteAll();
	}
}
