using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButtonOnClick : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject controlsCanvas;
    [SerializeField] private GameObject buttonToSelect;

    public void back()
    {
        EventSystem.current.SetSelectedGameObject(buttonToSelect);
        menuCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }
}
