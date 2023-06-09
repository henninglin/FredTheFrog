using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButtons : MonoBehaviour
{
    public int Loadscene;
  

    public void Start()
    {
        PlayerPrefs.SetInt("Player2", 0);
    }

    public void player2()
    {
        PlayerPrefs.SetInt("Player2", 1);
    }

    public void loadscene()
    {
        SceneManager.LoadScene(Loadscene);
    }


}
