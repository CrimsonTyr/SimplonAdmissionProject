using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlsButtonOnClick : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject controlsCanvas;
    [SerializeField] private GameObject buttonToSelect;

    public void controls()
    {
        EventSystem.current.SetSelectedGameObject(buttonToSelect);
        controlsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
}
