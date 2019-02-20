using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Handler))]
public class HandlerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Handler handler = (Handler)target;
		handler.maxLevelBeaten = Mathf.Clamp(handler.maxLevelBeaten, 1, UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings-1);
		PlayerPrefs.SetInt("MaximumLevelBeaten", handler.maxLevelBeaten);
	}
}
