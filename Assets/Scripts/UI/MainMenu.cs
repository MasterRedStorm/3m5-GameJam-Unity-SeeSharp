using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button helpButton;

    [SerializeField]
    private Button exitButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(HandlePlayButtonClick);
        helpButton.onClick.AddListener(HandleHelpButtonClick);
        exitButton.onClick.AddListener(HandleExitButtonClick);
    }

    private void OnDisable()
    {
        playButton.onClick.AddListener(HandlePlayButtonClick);
        helpButton.onClick.AddListener(HandleHelpButtonClick);
        exitButton.onClick.AddListener(HandleExitButtonClick);
    }

    private void HandlePlayButtonClick() => SceneHandler.Instance.LoadGameScene();

    private void HandleHelpButtonClick() => throw new NotImplementedException();

    private void HandleExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}