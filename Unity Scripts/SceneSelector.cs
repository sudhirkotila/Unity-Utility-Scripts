using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class SceneSelector : EditorWindow
{
    Vector2 scrollPos;
    string searchText = "";

    [MenuItem("Gametion/Tools/Scene Selector #&s")]
    public static void ShowWindow()
    {
        SceneSelector window = GetWindow<SceneSelector>();
        window.titleContent = new GUIContent(" Scene Selector", EditorGUIUtility.IconContent("SceneAsset Icon").image);
    }

    void OnGUI()
    {
        GUILayout.Label("Quick Scene Switcher", EditorStyles.boldLabel);

        // --- Search Bar ---
        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        // Using "SearchTextField" style makes it look like a native Unity search bar
        searchText = EditorGUILayout.TextField(searchText, EditorStyles.toolbarSearchField);

        if (GUILayout.Button("X", GUILayout.Width(20)))
        {
            searchText = "";
            GUI.FocusControl(null); // Clear focus to reset the UI
        }
        EditorGUILayout.EndHorizontal();

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scene.path);

            // SEARCH FILTER: Only show button if search is empty OR name matches search
            if (string.IsNullOrEmpty(searchText) || sceneName.ToLower().Contains(searchText.ToLower()))
            {
                // Visual cue for disabled scenes
                // if (!scene.enabled) GUI.contentColor = Color.gray;

                if (GUILayout.Button(sceneName, GUILayout.Height(25)))
                {
                    if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    {
                        EditorSceneManager.OpenScene(scene.path);
                    }
                }

                // Always reset color
                GUI.contentColor = Color.white;
            }
        }

        EditorGUILayout.EndScrollView();
    }
}