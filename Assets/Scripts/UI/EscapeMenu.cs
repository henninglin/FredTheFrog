using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject Menu;
    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Start") && isActivated == false)
        {
            isActivated = true;
            Menu.SetActive(true);
            Time.timeScale = 0f;
        }

        else if (Input.GetButtonUp("Start") && isActivated == true)
        {
            isActivated = false;
            Menu.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}