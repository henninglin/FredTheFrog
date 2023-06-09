using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //public GameObject pickupEffect;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Power Up Picked Up");
        if (other.gameObject.CompareTag("Chain"))
        {
            Debug.Log("Power Up Picked Up1");
            Pickup();
        }
    }

    void Pickup()
    {
        Debug.Log("Power Up Picked Up2");
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect to the player

        Destroy(gameObject);
    }
}
