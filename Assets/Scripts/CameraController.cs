using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 10f;
    public float followSharpness = 0.1f;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * moveSpeed);
        var newPos = new Vector2(player.transform.position.x + offset.x - 20, transform.position.y);
        transform.position = Vector3.Lerp(transform.position, newPos, blend);
    }
}
