using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonOnClick : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}