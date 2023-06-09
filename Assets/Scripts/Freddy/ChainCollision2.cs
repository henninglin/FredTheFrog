using UnityEngine;
using UnityEngine.UI;


public class ChainCollision2 : MonoBehaviour
{

    public int combocounter = 0;
    public float counter;
    public float count;
    public bool combostart = false;
    public Text combotext2;
    public Player2 player2;
    public AudioClip splitsound;

    private AudioSource AS;

    public void Start()
    {
        combotext2.text = "Combo:";
        AS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Chain2.IsFired = false;


        if (col.tag == "Ball")
        {
            col.GetComponent<Ball>().Split();
            AS.PlayOneShot(splitsound, 0.5F);
            combocounter++;
            combotext2.text = "Combo: " + combocounter.ToString();
            combostart = true;
            count = counter;
            player2.gainXP(100);
        }
    }

    public void resetcounter()
    {
        combocounter = 0;
        combotext2.text = "Combo:";
    }

    public void Update()
    {
        if (combostart)
        {

            count -= Time.deltaTime;

            if (count <= 0)
            {
                combostart = false;
                player2.gainXP(combocounter * 100);
                resetcounter();
            }
        }

    }
}