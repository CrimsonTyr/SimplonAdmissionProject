using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonOnClick : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("MyProject");
    }
}
