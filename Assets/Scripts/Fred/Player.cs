using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public bool facingRight;
    public bool canDash;
    public float speed = 4f;
    public float DashcooldownTime = 3f;
    public float IcecooldownTime = 5f;
    public float Dashdistance;
    public float health = 1;
    public float currentXP;    
    public int lvl;
    public Rigidbody2D rb;
    public Animator animator;    
    public Slider XPslider;    
    public Text lvltext;
    public AudioClip deathsound;
    public AudioClip LevelUpDing;
    public AudioClip Dashsound;
    private AudioSource AS;
    private float movement = 0f;
    public bool IceSwitch;
    public float Iceunlock = 5;
    public float Dashunlock = 10;

    public GameObject Spit;
    public GameObject Ice;
    public GameObject deathtext;
    public GameObject wonleveltext;
    public GameObject mouth;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject IceUI;
    public Image IceCD;
    public GameObject DashUI;
    public Image DashCD;

    public float dashfill;
    public float dashCoolDown;

    private bool triggerDash;

    public float icefill;
    public float IceCoolDown;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        triggerDash = false;
        currentXP = PlayerPrefs.GetFloat("XPp1");
        lvl = 1;
        lvl = PlayerPrefs.GetInt("LVL");    
        canDash = false;
        facingRight = false;
        lvltext.text = "Level:";
        AS = GetComponent<AudioSource>();
        Spit.SetActive(true);
        Ice.SetActive(false);
        IceSwitch = false;
        DashUI.SetActive(false);
        IceUI.SetActive(false);
    }

    void Update ()
    {
		movement = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(movement));
        XPslider.value = currentXP;
        lvltext.text = "Level: " + lvl.ToString();

        if (currentXP >= XPslider.maxValue)
        {
            XPslider.maxValue = XPslider.maxValue * 2;
            currentXP = 0;
            lvl++;
            PlayerPrefs.SetInt("LVL", lvl);
            AS.PlayOneShot(LevelUpDing, 1F);
        }

        if (transform.position.x < -5.34)
        {
            transform.position = new Vector2(-5.34f, transform.position.y);
        }

        if (transform.position.x > 5.38)
        {
            transform.position = new Vector2(5.38f, transform.position.y);
        }    
           

        if(wonleveltext.activeInHierarchy)
        {
            mouth.SetActive(false);
            animator.SetBool("Won", true);
        }

        if(lvl >= Iceunlock)
        {
            if (Input.GetButtonDown("Ice spit") && IceSwitch == false)
            {

                Invoke("IceActive", IcecooldownTime);
                Spit.SetActive(false);
                Ice.SetActive(true);
            }
            lock1.SetActive(false);
            IceUI.SetActive(true);
        }

        if (lvl >= Dashunlock && triggerDash== false)
        {
            triggerDash = true;
            canDash = true;
            lock2.SetActive(false);
            DashUI.SetActive(true);
        }

        if (dashCoolDown>0)
        {
            dashCoolDown -= Time.deltaTime;
            dashfill = Mathf.Lerp(0, 1, Mathf.InverseLerp(DashcooldownTime, 0, dashCoolDown));
            DashCD.fillAmount = dashfill;
        }

        if (Input.GetButtonDown("Dash") && canDash == true)
        {

            AS.PlayOneShot(Dashsound, 0.8F);
            dashCoolDown = DashcooldownTime;


            if (facingRight == false)
            {
                transform.position = new Vector2(transform.position.x - Dashdistance, transform.position.y);
            }
            else if (facingRight == true)
            {
                transform.position = new Vector2(transform.position.x + Dashdistance, transform.position.y);
            }

            canDash = false;
            Invoke("CoolDown", DashcooldownTime);
             

        }

        if (IceCoolDown > 0)
        {
            IceCoolDown -= Time.deltaTime;
            icefill = Mathf.Lerp(0, 1, Mathf.InverseLerp(IcecooldownTime, 0, IceCoolDown));
            IceCD.fillAmount = icefill;
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
        canDash = true;
        
    }

    void IceActive()
    {
        IceCoolDown = IcecooldownTime;
        Spit.SetActive(true);
        IceSwitch = false;
        Ice.SetActive(false);
    }


    void Death()
    {
        mouth.SetActive(false);
        Debug.Log("GAME OVER!");
        AS.PlayOneShot(deathsound, 0.8F);
        deathtext.SetActive(true);
        animator.SetBool("Death", true);
        StartCoroutine(resetlevel());
        currentXP = 0;
        PlayerPrefs.SetFloat("XPp1", currentXP);
        PlayerPrefs.SetInt("LVL", 1);
    }

    public void gainXP(float add)
    {
        currentXP += add;
        PlayerPrefs.SetFloat("XPp1", currentXP);
    }

    IEnumerator resetlevel()
        {            
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
