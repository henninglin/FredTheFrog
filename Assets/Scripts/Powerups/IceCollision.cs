using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCollision : MonoBehaviour
{
    public int combocounter = 0;
    public float counter;
    public float count;
    public bool combostart = false;
    public Text combotext;
    public Player player;
    public AudioClip splitsound;

    private AudioSource AS;

    public void Start()
    {
        combotext.text = "Combo:";
        AS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Ball")
        {
            col.GetComponent<Ball>().Split();
            Ice.IsFired = false;
            AS.PlayOneShot(splitsound, 0.5F);
            combocounter++;
            combotext.text = "Combo: " + combocounter.ToString();
            combostart = true;
            count = counter;
            player.gainXP(100);
        }

        if (col.tag == "PowerUp")
        {
            Debug.Log("e");
            Destroy(col.gameObject);
            Ice.IsFired = false;
        }

    }

    public void resetcounter()
    {
        combocounter = 0;
        combotext.text = "Combo:";
    }

    public void Update()
    {
        if (combostart)
        {

            count -= Time.deltaTime;

            if (count <= 0)
            {
                combostart = false;
                player.gainXP(combocounter * 100);
                resetcounter();
            }
        }

    }
}
