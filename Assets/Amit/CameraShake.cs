using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    private void Start()
    {
        PlayerHealth.OnPlayerHitEvent += x =>
        {
            StartCoroutine(ShakeIt(0.15f, 0.4f));
        };
    }

    public IEnumerator ShakeIt(float duration, float magnitude)
    {
        var originalPos = transform.localPosition;

        float elapsed = 0;

        while (duration > elapsed)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            
            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
