using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExitButton : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject character;
    private bool gameIsPaused;

    void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                Pause();
            }
            else
            {
                PlayGame();
            }
        }
       // Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    void PlayGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        character.GetComponent<FpsMovement>().SetPausedState(gameIsPaused);
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
        character.GetComponent<FpsMovement>().SetPausedState(gameIsPaused);
    }

    public bool GetPausedState()
    {
        return gameIsPaused;
    }
}
