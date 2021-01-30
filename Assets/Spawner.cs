﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnerObjects;
    [SerializeField] private GameObject player;
    [SerializeField] float destroyTime = 5f;
    [SerializeField] private float minSpawnerTime = 3f;
    [SerializeField] private float maxSpawnerTime = 5f;
    private float timeLastSpawn = 0;
    public float spawnDistance = 20;

    private float randomTime;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(minSpawnerTime, maxSpawnerTime);
        //PlayerMovement.OnPlayerHit += PlayerHurt();
    }

    // Update is called once per frame
    void Update()
    {
        timeLastSpawn += Time.deltaTime;

        if (timeLastSpawn > randomTime)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int randomObj = Random.Range(0, spawnerObjects.Count);
        GameObject obj = Instantiate(spawnerObjects[randomObj]);
        obj.transform.position = new Vector2(player.transform.position.x + spawnDistance, obj.transform.position.y);
        timeLastSpawn = 0;

        randomTime = Random.Range(minSpawnerTime, maxSpawnerTime);
        Destroy(obj, destroyTime);
    }

    private void PlayerHurt()
    {
        timeLastSpawn = 0;
    }

    public void RemoveItem(int index)
    {
       spawnerObjects.RemoveAt(index);
    }
}
