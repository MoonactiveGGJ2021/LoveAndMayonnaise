using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const string OBSTACLE_TAG_NAME = "Obstacle";
    private const string GOODSHIT_TAG_NAME = "GoodShit";

    public Tooltip tooltip;
    public int m_LifeCounter { get; private set; } = 7;

    public static event Action<int> OnPlayerHitEvent;
    public static event Action OnPlayerDeath;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(OBSTACLE_TAG_NAME))
        {
            OnPlayerHit();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(OBSTACLE_TAG_NAME))
        {
            OnPlayerHit();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag(GOODSHIT_TAG_NAME))
        {
            OnGoodShitHit();
            Destroy(other.gameObject);
        }
    }

    private void OnGoodShitHit()
    {
        tooltip.ActiveGoodShit();
        var anim = tooltip.GetComponent<Animator>();
        anim.SetTrigger("Active");
    }

    private void OnPlayerHit()
    {
        m_LifeCounter -= 1;

        if (m_LifeCounter > 0)
        {
            OnPlayerHitEvent?.Invoke(m_LifeCounter);
        }
        else
        {
            Debug.Log("death");
            OnPlayerHitEvent?.Invoke(m_LifeCounter);
            OnPlayerDeath?.Invoke();
        }
    }
    
    #if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnPlayerHit();
        }
    }

#endif
}
