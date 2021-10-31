using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup menu;
    [SerializeField] private Button[] buttons;
    [SerializeField] private ButtonColorScheme bttnDesign;

    public int _activeButton;

    public int ActiveButton
    {
        get => _activeButton;
        set
        {
            _activeButton = Mathf.Clamp(value, 0, buttons.Length);
            OnActiveButtonChange();
        }
    }
    
    private void Start() => Hide();

    public void Show()
    {
        menu.gameObject.SetActive(true);
        PauseGame();
    }

    public void Hide()
    {
        menu.gameObject.SetActive(false);
        ResumeGame();
    }
    
    private void PauseGame ()
    {
        Time.timeScale = 0f;
        // AudioListener.pause = true;
    }

    private void ResumeGame ()
    {
        Time.timeScale = 1;
        // AudioListener.pause = false;
    }

    private void OnActiveButtonChange()
    {
        for (var idx = 0; idx < buttons.Length; idx += 1)
        {
            var colors = idx == ActiveButton ? bttnDesign.normal :  bttnDesign.active;
            ChangeBttnColors(idx, colors);
        }
    }

    private void ChangeBttnColors(int index, ColorBlock colors)
    {
        var bttn = buttons[index];
        bttn.colors = colors;
        /*bttn.colors.normalColor = colors.normal;
        bttn.colors.highlightedColor = colors.highlighted;
        bttn.colors.pressed = colors.pressed;
        bttn.colors.selected = colors.selected;
        bttn.colors.disabled = colors.disabled;*/
    }
}
