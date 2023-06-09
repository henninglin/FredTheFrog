using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniForm : MonoBehaviour
{
    public float multiplier = 0.5f;
    public float duration = 5f;
    public float MinicooldownTime = 5f;
    public bool canShrink;
    private bool isshrunk;
    public Transform player;
    public AudioClip minisound;
    public AudioClip Maximizesound;

    public Image MiniCD;
    public float MiniCooldown;
    public float minifill;

    private AudioSource AS;

    // Start is called before the first frame update
    private void Start()
    {
        canShrink = true;
        AS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Mini Form"))
        {
            if (canShrink == true)
            {
                isshrunk = true;
                Invoke("revertBack", duration);
                player.transform.localScale *= multiplier;    
                AS.PlayOneShot(minisound, 0.5F);
                canShrink = false;  

            }
        }

        if(isshrunk == true)
        {
            isMini();
        }
    }

    void isMini()
    {
        
        MinicooldownTime -= Time.deltaTime;
        minifill = Mathf.Lerp(0, 1, Mathf.InverseLerp(MiniCooldown, 0, MinicooldownTime));
        MiniCD.fillAmount = minifill;
    }

    void revertBack()
    {
        player.transform.localScale /= multiplier;
        Invoke("CoolDown", MinicooldownTime);
        AS.PlayOneShot(Maximizesound, 0.5F);
        isshrunk = false;
        
    }

   void CoolDown()
    {
        canShrink = true;
        MinicooldownTime = MiniCooldown;
    }


}
