using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour {

	public Transform mouth;
	public float speed = 2f;
	public static bool IsFired;
    public static bool IsDoubleFired;
    public AudioClip watersound;

    private AudioSource AS;
    private bool canplaysound;


    // Use this for initialization
    void Start ()
    {
		IsFired = false;
        IsDoubleFired = false;
        AS = GetComponent<AudioSource>();
        canplaysound = true;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Normal shot"))
		{
            IsFired = true;

            if(canplaysound)
            {
                AS.PlayOneShot(watersound, 0.8F);
                canplaysound = false;
            }
        }

        if (IsFired)
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;

        }
        else
        {
            transform.position = mouth.position;
            transform.localScale = new Vector3(1f, 0f, 1f);
            canplaysound = true;
        }


    }

}
