using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayVanilla()
    {
        SceneManager.LoadScene("Easy Level");
    }

    public void PlayHardcore()
    {
        SceneManager.LoadScene("Hard Level");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
