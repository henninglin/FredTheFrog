using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public GameObject title;
    public GameObject by;
    public GameObject Specialthanks;

    public AudioClip textpopsound;

    public Image black;
    public Animator fadinganim;

    private AudioSource AS;

    private void Start()
    {
        StartCoroutine(showtext());
        AS = GetComponent<AudioSource>();
    }


    IEnumerator showtext()
    {
        Debug.Log("klar til credits");
        title.SetActive(false);
        by.SetActive(false);
        Specialthanks.SetActive(false);
        yield return new WaitForSeconds(2);
        title.SetActive(true);
        AS.PlayOneShot(textpopsound, 1F);
        yield return new WaitForSeconds(3);
        by.SetActive(true);
        AS.PlayOneShot(textpopsound, 1F);
        yield return new WaitForSeconds(3);
        by.SetActive(false);
        Specialthanks.SetActive(true);
        AS.PlayOneShot(textpopsound, 1F);
        yield return new WaitForSeconds(3);
        title.SetActive(false);
        Specialthanks.SetActive(false);
        fadinganim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(0);
    }


}
