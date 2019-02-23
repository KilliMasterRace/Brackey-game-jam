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
		Handler.INSTANCE.maxLevelBeaten = 0;
		Handler.INSTANCE.SaveMaximumLevelBeaten();
		Handler.INSTANCE.LoadNextScene();
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
	public void ReturnToMenu()
	{
		PauseMenu temp = GetComponent<PauseMenu>();
		if (temp != null)
			temp.UnPauseGame();
		Handler.INSTANCE.LoadMenuScene();
	}

	public void Restart()
	{
		Handler.INSTANCE.LoadCurrentScene();
	}
}
