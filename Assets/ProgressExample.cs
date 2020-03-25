using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressExample : MonoBehaviour
{
    public int MaxCount;

    [SerializeField] private Slider progressSlider;
    
    void Start()
    {
        StartCoroutine(HeavyMethod(new Progress<float>(dd)));
    }

    private void dd(float s)
    {
        progressSlider.value = s;
    }
    
    private IEnumerator HeavyMethod(IProgress<float> progress)
    {
        for (int i = 0; i <= MaxCount; i++)
        {
            progress.Report((float)i/MaxCount);
            Debug.Log(i);
            yield return null;
        }
            
        yield break;
    }
}
