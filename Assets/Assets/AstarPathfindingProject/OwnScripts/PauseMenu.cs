﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{  
    public static bool GameIsPaused;
    public GameObject pausedMenuUI;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

public void Resume() {

        pausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause() {

            pausedMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

    public void LoadMenu()
        {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        }

    public void QuitGame()
    {
        Application.Quit();
    }
}
 