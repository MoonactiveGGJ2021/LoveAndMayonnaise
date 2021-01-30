using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHUD : MonoBehaviour
{
    public Sprite[] SandwichStates/* = new List<Sprite>()*/;

    [SerializeField]
    private PlayerHealth m_PlayerHealth;

    [SerializeField] 
    private Image m_SandwitchLifeImage;

    private void Start()
    {
        m_SandwitchLifeImage.sprite = SandwichStates[SandwichStates.Length - 1];
        
        PlayerHealth.OnPlayerHitEvent += OnPlayerHitEvent;
    }

    private void OnPlayerHitEvent(int lifeLeft)
    {
        int sandwichIndex = lifeLeft - 1;

        if (sandwichIndex >= 0)
        {
            m_SandwitchLifeImage.sprite = SandwichStates[sandwichIndex];
        }
        else
        {
            m_SandwitchLifeImage.enabled = false;
        }
    }
}
