using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitIcon : MonoBehaviour
{
   
    public static bool GameIsPaused = false;
    void Pause()
    {
       
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToScene(string sceneName)
    {
        Pause();
        if (GameIsPaused) {
            Debug.Log("The game is paused");
        }
        SceneManager.LoadScene(sceneName);

    }
    public void Resume()
    {
        
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("DuoSnakeGame");
    }

    /*public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
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
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }*/
}
