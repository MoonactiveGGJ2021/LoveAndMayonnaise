using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Tooltip.OnGameWin += PlayerWin;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= PlayerDied;
        Tooltip.OnGameWin -= PlayerWin;
    }

    private bool canRestart = false;
    
    private void PlayerDied()
    {
        m_GameOverScreen.SetActive(true);
        canRestart = true;
    }

    private void PlayerWin()
    {
        m_WinnerScreen.SetActive(true);
        canRestart = true;
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

        if (canRestart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
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
        yield return new WaitForSeconds(2.4f);
        CameraAnimator.enabled = false;
        
        OnGameStarted?.Invoke();
    }
}
