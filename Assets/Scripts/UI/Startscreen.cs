using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startscreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup startscreenOverlay;
    [SerializeField] private CanvasGroup titleOverlay;
    [SerializeField] private GameObject titleBackground;
    // [SerializeField] private CanvasRenderer MainMenu;

    [SerializeField] private float fadeStartscreenInSeconds = 2;
    [SerializeField] private float timeToKeepTitleScreen = 4;
    [SerializeField] private float fadeTitleInSeconds = 2;

    [SerializeField] private AnimationCurve startscreenVisibility = AnimationCurve.EaseInOut(0,1,1,0);
    [SerializeField] private AnimationCurve titleScreenVisibility = AnimationCurve.EaseInOut(0,1,1,0);

#if UNITY_EDITOR
    [SerializeField]
    private bool skipFadingAnimation;
#endif
    
    private float timePassed;

    private void Awake()
    {
        startscreenOverlay.gameObject.SetActive(true);
        titleBackground.gameObject.SetActive(true);
    }

    private void Start()
    {
#if UNITY_EDITOR
        if (!skipFadingAnimation)
        {
#endif
            StartCoroutine(HideStartscreenOverlay());
#if UNITY_EDITOR
        }
        else
        {
            startscreenOverlay.gameObject.SetActive(false);
            titleBackground.gameObject.SetActive(false);
        }
#endif
    }

    private IEnumerator HideStartscreenOverlay()
    {
        var linear = 0f;
        var alpha = 0f;
        while (timePassed < fadeStartscreenInSeconds)
        {
            timePassed += Time.deltaTime;
            linear = Mathf.Clamp01(timePassed / fadeStartscreenInSeconds);
            alpha = startscreenVisibility.Evaluate(linear);
            startscreenOverlay.alpha = alpha;
            yield return null;
        }
        
        startscreenOverlay.alpha = alpha;
        startscreenOverlay.gameObject.SetActive(false);
        timePassed = 0;

        while (timePassed < timeToKeepTitleScreen)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        
        timePassed = 0;

        while (timePassed < fadeTitleInSeconds)
        {
            timePassed += Time.deltaTime;
            linear = Mathf.Clamp01(timePassed / fadeTitleInSeconds);
            alpha = titleScreenVisibility.Evaluate(linear);
            titleOverlay.alpha = alpha;
            yield return null;
        }
        
        titleOverlay.alpha = alpha;
        titleBackground.SetActive(false);
        timePassed = 0;
    }
}
