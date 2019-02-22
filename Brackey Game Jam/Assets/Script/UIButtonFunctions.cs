using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour
{
	public void ContinueSavedGame()
	{
		Handler.INSTANCE.LoadMaximumLevelBeaten();
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
		Handler.INSTANCE.LoadMenuScene();
	}
}
