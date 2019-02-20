using UnityEngine;
using UnityEditor;

public class PlayerPrefsEditorTool : EditorWindow
{
	[MenuItem("Tools/PlayerPrefsTool")]
	public static void ShowWindow()
	{
		GetWindow<PlayerPrefsEditorTool>("PlayerPrefs");
	}

	void OnGUI()
	{
		if (GUILayout.Button("Delete ALL keys and it's values"))
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("Deleted all PlayerPrefs!");
		}
	}
}
