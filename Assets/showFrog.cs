using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showFrog : MonoBehaviour
{
    public GameObject frog;

    // Start is called before the first frame update
    void Start()
    {
        frog.SetActive(false);
    }

    // Update is called once per frame
    private void OnMouseOver()
    {
        frog.SetActive(true);
    }

    private void OnMouseExit()
    {
        frog.SetActive(false);
    }
}
