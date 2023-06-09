using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int targetballs;
    private int balls;
    public GameObject wontext;
    public float nextstagetimer;

    public void balldisable()
    {
        balls++;
        checklevel();
    }

    private void checklevel()
    {
        if (balls >= targetballs)
        {
            wontext.SetActive(true);
            Invoke("nextlevel", nextstagetimer);
        }
    }

    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
