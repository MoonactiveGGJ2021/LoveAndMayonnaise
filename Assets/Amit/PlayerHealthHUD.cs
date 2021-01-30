using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHUD : MonoBehaviour
{
    public Sprite[] SandwichStates/* = new List<Sprite>()*/;

    [SerializeField] 
    private Image m_SandwitchLifeImage;

    private void Start()
    {
        m_SandwitchLifeImage.enabled = false;
        
        m_SandwitchLifeImage.sprite = SandwichStates[SandwichStates.Length - 1];
        
        PlayerHealth.OnPlayerHitEvent += OnPlayerHitEvent;

        MainMenuHandler.OnGameStarted += () =>
        {
            if (!m_SandwitchLifeImage.enabled)
            {
                m_SandwitchLifeImage.enabled = true;
            }
        };
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
