using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour
{
	public void ContinueSavedGame()
	{
		if (PlayerPrefs.GetInt("MaximumLevelBeaten") > 0)
		{
			Handler.INSTANCE.LoadMaximumLevelBeaten();
		}
	}

	public void NewGame()
	{
		Handler.INSTANCE.LoadNextScene();
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
	public void ReturnToMenu()
	{
		GetComponent<PauseMenu>().UnPauseGame();
		Handler.INSTANCE.LoadMenuScene();
	}

	public void Restart()
	{
		Handler.INSTANCE.LoadCurrentScene();
	}
}
