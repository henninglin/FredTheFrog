using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ice : MonoBehaviour
{

    public Transform mouth;
    public float speed = 2f;
    public static bool IsFired;
    public float IcecooldownTime = 5f;
    public AudioClip icesound;
    public Image IceCD;

    private AudioSource AS;

    // Use this for initialization
    void Start()
    {
        IsFired = false;
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Normal shot"))
        {
            IsFired = true;
            //Invoke("CoolDown", IcecooldownTime);
            AS.PlayOneShot(icesound, 0.8F);
            

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
