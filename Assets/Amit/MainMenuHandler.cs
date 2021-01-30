using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    private const string START_ANIMATOR_TRIGGER = "Start";
    private static readonly int Start = Animator.StringToHash(START_ANIMATOR_TRIGGER);

    [SerializeField] 
    private Animator CameraAnimator;
    
    private bool canStart;

    // Update is called once per frame
    void Update()
    {
        if (canStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CameraAnimator.SetTrigger(id: Start);
            }
        }
    }
}
