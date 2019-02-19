using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler : MonoBehaviour
{
	#region Variables
	[HideInInspector]
	public static Handler INSTANCE; // The INSTANCE of the Handler class
	public int maxLevelBeaten; // The maximum level the player has reached in this game session	
	#endregion

	#region Unity Built-in Functions
	void Start()
    {
        //Make a singleton
        INSTANCE = this;

        // DO NOT destroy this object on ANY scene load
        DontDestroyOnLoad(gameObject);
        // Load the first scene (This scene is just a initialization scene)
        SceneManager.LoadScene(1);
    }
	#endregion

	#region SceneManagment
	public void LoadScene(int _BuildIndex)
    {
        // LoadScene number _BuildIndex
        SceneManager.LoadScene(_BuildIndex);
    }

    public void LoadNextScene()
    {
        // LoadScene number our current scene + 1
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCurrentScene()
    {
        // Load our currently active scene
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	#endregion

	#region Other Stuff...
	public void SaveMaximumLevelBeaten()
	{
		// Set MaximumLevelBeaten to maxLevelBeaten 
		PlayerPrefs.SetInt("MaximumLevelBeaten", maxLevelBeaten);
		// Save the PlayerPrefs, incase of a not proper application termination (etc. crashes, power loss, disconect(if in webGL))
		PlayerPrefs.Save();
	}

	public void LoadMaximumLevelBeaten()
	{
		maxLevelBeaten = PlayerPrefs.GetInt("MaximumLevelBeaten");

		LoadScene(maxLevelBeaten);
	}

	#endregion
}
