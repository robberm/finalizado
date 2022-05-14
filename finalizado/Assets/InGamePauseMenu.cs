using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InGamePauseMenuu : MonoBehaviour
{
    void Update()
    {
        if (Application.isPlaying && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
        }
    }


    void goBackMenu()
    {
        SceneManager.LoadScene(0);
    }
    void resumeGame()
    {
        Time.timeScale = 1;
    }
}

