using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_SoundEffectSorce;

    [SerializeField]
    private AudioClip[] m_HitSounds;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.OnPlayerHitEvent += OnPlayerHit;
    }

    private void OnPlayerHit(int life)
    {
        int randomSoundIndex = Random.Range(0, m_HitSounds.Length);
        var randomSound = m_HitSounds[randomSoundIndex];

        m_SoundEffectSorce.clip = randomSound;
        m_SoundEffectSorce.Play();
    }
}
