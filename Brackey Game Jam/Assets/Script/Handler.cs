using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler : MonoBehaviour
{
    public Handler INSTANCE;

    void Start()
    {
        //Make a singleton
        INSTANCE = this;

        // DO NOT destroy this object on ANY scene load
        DontDestroyOnLoad(gameObject);
        // Load the first scene (This scene is just a initialization scene)
        SceneManager.LoadScene(1);
    }

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
}
