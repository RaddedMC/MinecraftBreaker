using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstScene()
    {
        try {
            FindObjectOfType<StatusScript>().ResetScore();
        } catch (NullReferenceException)
        {

        }
        SceneManager.LoadScene(0);
    }

    public void Leave()
    {
        Application.Quit();
    }
}
