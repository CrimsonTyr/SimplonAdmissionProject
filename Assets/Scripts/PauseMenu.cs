using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject resumeButton;

    public static bool isPaused;

    void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!WinScript.playerWon)
        {
            if (Input.GetKeyDown("escape") && !isPaused)
                pause();
            else if (Input.GetKeyDown("escape") && isPaused)
                play();
            if (isPaused && EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(resumeButton);
            if (!isPaused && Cursor.visible == true)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (isPaused && Cursor.visible == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(resumeButton);
        pauseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        pauseCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1;
    }
}
