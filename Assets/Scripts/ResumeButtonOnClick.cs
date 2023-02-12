using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeButtonOnClick : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject resumeButton;

    public void resume()
    {
        PauseMenu.isPaused = false;
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
}
