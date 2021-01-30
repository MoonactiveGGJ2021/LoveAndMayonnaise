using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbParallax : MonoBehaviour
{
    public float fraction = 0.01f;
    public GameObject player;
    private Rigidbody2D playerRigidbody;
    private Rigidbody2D ownRigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        ownRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ownRigidbody2D.velocity = playerRigidbody.velocity * fraction;
    }
}
