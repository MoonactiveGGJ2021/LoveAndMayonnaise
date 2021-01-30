using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public List<GameObject> goodShit;
    private int count;

    public static event Action OnGameWin;
    
    public void ActiveGoodShit()
    {
        /*if (count <= goodShit.Count - 1)
        {
            Debug.Log("Active");
            goodShit[count].SetActive(true);
            count++;
        }*/

        if (true/*count == goodShit.Count*/)
        {
            Debug.Log("Win");
            OnGameWin?.Invoke();

            var player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().Stop();
                player.GetComponentInChildren<Animator>().SetTrigger("Win");
            }
        }
    } 
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
