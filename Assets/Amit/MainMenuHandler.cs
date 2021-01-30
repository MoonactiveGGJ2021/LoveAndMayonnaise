using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    private const string START_ANIMATOR_TRIGGER = "Start";
    private static readonly int StartTrigger = Animator.StringToHash(START_ANIMATOR_TRIGGER);

    public static event Action OnGameStarted;

    [SerializeField] 
    private Animator CameraAnimator;

    [Header("Screens")]
    [SerializeField] 
    private GameObject m_PressToStartText;
    [SerializeField] 
    private GameObject m_GameOverScreen;
    [SerializeField] 
    private GameObject m_WinnerScreen;

    private bool canStart = true;

    private void Start()
    {
        PlayerHealth.OnPlayerDeath += PlayerDied;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= PlayerDied;
    }

    private void PlayerDied()
    {
        m_GameOverScreen.SetActive(true);
        canStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGameplay();
            }
        }
    }

    private void StartGameplay()
    {
        canStart = false;
        m_PressToStartText.SetActive(false);
        CameraAnimator.SetTrigger(id: StartTrigger);

        StartCoroutine(WaitForFirstAnimationEnd());
    }

    private IEnumerator WaitForFirstAnimationEnd()
    {
        yield return new WaitForSeconds(2f);
        
        OnGameStarted?.Invoke();
    }
}
