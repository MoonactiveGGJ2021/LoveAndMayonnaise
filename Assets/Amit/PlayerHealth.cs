using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const string OBSTACLE_TAG_NAME = "Obstacle";

    [SerializeField]
    private Collider2D m_Collider;

    public int m_LifeCounter { get; private set; } = 7;

    public static event Action<int> OnPlayerHitEvent;
    public event Action OnPlayerDeath;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(OBSTACLE_TAG_NAME))
        {
            OnPlayerHit();
        }
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
