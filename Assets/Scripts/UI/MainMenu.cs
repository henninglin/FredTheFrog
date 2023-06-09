using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetFloat("XPp1", 0);
        PlayerPrefs.SetFloat("XPp2", 0);
        PlayerPrefs.SetInt("LVL", 1);
        PlayerPrefs.SetInt("LVL", 1);
    }
    public void StartGame()
    {
    SceneManager.LoadScene(1);
        Debug.Log("LoadScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}

