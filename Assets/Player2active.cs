using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2active : MonoBehaviour
{

    public GameObject player2;
    public GameObject p2UI;


    // Start is called before the first frame update
    void Start()
    {
        

        if (PlayerPrefs.GetInt("Player2")==1)
        {
            player2.SetActive(true);
            p2UI.SetActive(true);
        }
        else
        {
            player2.SetActive(false);
            p2UI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
