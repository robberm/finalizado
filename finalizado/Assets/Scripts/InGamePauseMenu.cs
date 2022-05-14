using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePauseMenu : MonoBehaviour
{
    public Canvas menuEscape;
    private void Start()
    {
        disableCanvas();
    }
    void Update()
    {
       
        if ( Input.GetKeyDown(KeyCode.Escape))
        {
            enableCanvas();
            Time.timeScale = 0f;
        }
    }
    void enableCanvas()
    {
       menuEscape.GetComponent<Canvas>().enabled = true;
    }
    void disableCanvas()
    {
        menuEscape.GetComponent<Canvas>().enabled = false;
    }
    public void goBackMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        disableCanvas();
    }
}

