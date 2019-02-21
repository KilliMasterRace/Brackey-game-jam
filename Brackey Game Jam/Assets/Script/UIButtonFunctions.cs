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

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
