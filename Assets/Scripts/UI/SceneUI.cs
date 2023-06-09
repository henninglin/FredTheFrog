using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour
{

    public int currentstage;
    public Text stagetext;

    // Start is called before the first frame update
    void Start()
    {
        currentstage = SceneManager.GetActiveScene().buildIndex;
        stagetext.text = "stage: " + currentstage.ToString();
    }
}
