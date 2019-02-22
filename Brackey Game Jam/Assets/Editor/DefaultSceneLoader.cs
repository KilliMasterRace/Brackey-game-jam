#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


[InitializeOnLoadAttribute]
public static class DefaultSceneLoader
{
	static DefaultSceneLoader()
	{
		EditorApplication.playModeStateChanged += LoadDefaultScene;
	}

	static void LoadDefaultScene(PlayModeStateChange state)
	{
		if (state == PlayModeStateChange.ExitingEditMode)
		{

			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		}

		if (state == PlayModeStateChange.EnteredPlayMode && EditorSceneManager.GetActiveScene().buildIndex != 0)
		{
			//new GameObject("CREATED BY EDITOR SCRIPTS").AddComponent<Handler>();
			EditorSceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Additive);
			EditorSceneManager.UnloadSceneAsync(0);
		}
	}
}

#endif