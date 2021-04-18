using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    // Defy the laws of physics! Control time!
    [Range(0.1f, 10f)] [SerializeField] float timeScaler = 1;

    // Boring non-time destroying variables
    [SerializeField] int currentScore = 0;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject canvas;
    GameObject[] pauseScreen;

    private void Awake()
    {
        // Hide the pausemenu
        pauseScreen = GameObject.FindGameObjectsWithTag("PauseMenu");
        foreach (GameObject item in pauseScreen)
        {
            item.SetActive(false);
        }

        // DDoL
        int gameStatusCount = FindObjectsOfType<StatusScript>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Handles esc key presses
    void Update()
    {
        if (!paused)
        {
            Time.timeScale = timeScaler;
        }
        scoreText.text = currentScore.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    // Toggles pausing
    bool paused = false;
    private void pauseGame()
    {
        if (!paused)
        {
            paused = true;
            foreach (GameObject item in pauseScreen)
            {
                item.SetActive(true);
            }
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            foreach (GameObject item in pauseScreen)
            {
                item.SetActive(false);
            }
        }
    }

    // Triggered upon block collision
    public void AddToScore(int amount)
    {
        currentScore += amount;
    }
    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
