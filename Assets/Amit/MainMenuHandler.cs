using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    private const string START_ANIMATOR_TRIGGER = "Start";
    private static readonly int Start = Animator.StringToHash(START_ANIMATOR_TRIGGER);

    public static event Action OnGameStarted;

    [SerializeField] 
    private Animator CameraAnimator;

    [SerializeField] 
    private GameObject m_PressToStartText;

    private bool canStart = true;

    // Update is called once per frame
    void Update()
    {
        if (canStart)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartGameplay();
            }
        }
    }

    private void StartGameplay()
    {
        canStart = false;
        m_PressToStartText.SetActive(false);
        CameraAnimator.SetTrigger(id: Start);

        StartCoroutine(WaitForFirstAnimationEnd());
    }

    private IEnumerator WaitForFirstAnimationEnd()
    {
        yield return new WaitForSeconds(2f);
        
        OnGameStarted?.Invoke();
    }
}
