using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //[SerializeField] AudioClip;
    //[SerializeField] int points = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //play animation
        //play audio 
        //add point
        Destroy(gameObject);
    }
}