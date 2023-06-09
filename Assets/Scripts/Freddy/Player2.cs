using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class Player2 : MonoBehaviour {

    public bool facingRight = false;
    public bool canShield;
    public float speed = 4f;
    public float health = 1;
    public float shieldcooldownTime = 5f;
    public GameObject Shield;
    public GameObject shieldsound;
    public AudioClip shieldpopsound;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioClip deathsound;
    private AudioSource AS;
    private float movement = 0f;
    public GameObject Locked1;
    public GameObject Locked2;
    public GameObject Locked3;
    public GameObject ShieldUI;
    public Image ShieldCD;
    public GameObject MiniUI;
    public Image MiniCD;
    public float Miniunlock = 5;
    public float Shieldunlock = 10;

    public float shieldCooldown;
    private float shieldfill;
    public GameObject deathtext;

    public Slider XPslider;
    public Text lvltext;
    public float currentXP;
    public int lvl;
    public AudioClip LevelUpDing;
    public GameObject wonleveltext;
    public GameObject mouth;
    public MiniForm mf;

    private void Start()
    {
        currentXP = PlayerPrefs.GetFloat("XPp2");
        AS = GetComponent<AudioSource>();
        canShield = false;
        Shield.SetActive(false);
        shieldCooldown = 0;
        lvl = 1;
        lvl = PlayerPrefs.GetInt("LVLp2");
        lvltext.text = "Level:";
        MiniUI.SetActive(false);
        ShieldUI.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
		movement = Input.GetAxisRaw("Horizontal2") * speed;
        animator.SetFloat("Speed", Mathf.Abs(movement));
        XPslider.value = currentXP;
        lvltext.text = "Level: " + lvl.ToString();

        if (Input.GetButtonDown("ActivateShield"))
        {
            health = 2;
            Shield.SetActive(true);
            canShield = false;
            
            
        }

        if (currentXP >= XPslider.maxValue)
        {
            XPslider.maxValue = XPslider.maxValue * 2;
            currentXP = 0;
            lvl++;
            PlayerPrefs.SetInt("LVLp2", lvl);
            AS.PlayOneShot(LevelUpDing, 1F);
        }

        if (shieldCooldown > 0)
        {
            shieldCooldown -= Time.deltaTime;
            shieldfill = Mathf.Lerp(0, 1, Mathf.InverseLerp(shieldcooldownTime, 0, shieldCooldown));
            ShieldCD.fillAmount = shieldfill;
            //shieldfill = 1 / shieldCooldown;

        }
        else
        {
            shieldCooldown = 0;
        }


        if (health >= 2)
        {
            shieldsound.SetActive(true);
        }
        else
        {
            shieldsound.SetActive(false);
        }

        if (wonleveltext.activeInHierarchy)
        {
            mouth.SetActive(false);
            animator.SetBool("Won", true);
        }

        if (lvl >= Miniunlock)
        {
            mf.canShrink = true;
            Locked1.SetActive(false);
            MiniUI.SetActive(true);
        }

        if (lvl >= Shieldunlock)
        {
            canShield = true;
            Locked2.SetActive(false);
            ShieldUI.SetActive(true);
        }
    }

	void FixedUpdate ()
	{
        rb.MovePosition(rb.position + new Vector2 (movement * Time.fixedDeltaTime, 0f));

        if (movement > 0 && !facingRight)
            Flip();
        else if (movement < 0 && facingRight)
            Flip();
    }

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.tag == "Ball")
		{
            if (health >= 2)
            {
                Shield.SetActive(false);
                shieldCooldown = shieldcooldownTime;
                col.collider.GetComponent<Ball>().Split();
                Invoke("CoolDown", shieldcooldownTime);
                Debug.Log("Shield Split");
                health = 1;
            }

            if (health == 1)
            {
                AS.PlayOneShot(shieldpopsound, 0.8F);
            }

            if (health <= 0)
            {
                Death();
            }
            health--;
        }
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void CoolDown()
    {
        canShield = true;
    }

    void Death()
    {
        Debug.Log("GAME OVER!");
        AS.PlayOneShot(deathsound, 0.8F);
        deathtext.SetActive(true);
        animator.SetBool("Death", true);
        StartCoroutine(resetlevel());
        currentXP = 0;
        PlayerPrefs.SetFloat("XPp2", currentXP);
        PlayerPrefs.SetInt("LVLp2", 1);

    }

        IEnumerator resetlevel()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    public void gainXP(float add)
    {
        currentXP += add;
        PlayerPrefs.SetFloat("XPp2", currentXP);
    }
}
