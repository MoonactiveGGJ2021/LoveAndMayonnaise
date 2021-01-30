using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public List<GameObject> goodShit;
    private int count;

    public void ActiveGoodShit()
    {
        if (count <= goodShit.Count - 1)
        {
            Debug.Log("Active");
            goodShit[count].SetActive(true);
            count++;
        }

        if (count > goodShit.Count)
        {
            Debug.Log("Win");
        }
    } 
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
