using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunction : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene(int sceneindex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneindex);
    }
}
