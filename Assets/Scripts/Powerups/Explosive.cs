using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{

    public Transform mouth;
    public float speed = 2f;
    public static bool IsFired;
    public static bool IsDoubleFired;


    // Use this for initialization
    void Start()
    {
        IsFired = false;
        IsDoubleFired = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            IsFired = true;
        }

        if (IsFired)
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
        }
        else
        {
            transform.position = mouth.position;
            transform.localScale = new Vector3(1f, 0f, 1f);
        }


    }

}
