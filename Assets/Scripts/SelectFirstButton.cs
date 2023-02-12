using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectFirstButton : MonoBehaviour
{
    [SerializeField] private Button buttonToSelect;
    [SerializeField] private GameObject defaultButton;

    void Start()
    {
        buttonToSelect.Select();
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(defaultButton);
    }
}