using UnityEngine;
using UnityEditor;

public class MenuItems
{
	[MenuItem ("Sudhir's ShortCuts/Clear PlayerPrefs")]
	private static void NewMenuOption ()
	{
		PlayerPrefs.DeleteAll();
	}
}