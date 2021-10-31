using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonGroup
{
    public Action EnableAction;
    public Action DisableAction;
    
    [SerializeField]
    private List<MixerButton> buttons;

    [SerializeField]
    private int requiredButtonsToPress;

    private int amountOfActiveButtons;
    
    private int ActiveButtons
    {
        get => amountOfActiveButtons;
        set {
            amountOfActiveButtons = Math.Clamp(value, 0, buttons.Count - 1);
        }
    }

    private void Start()
    {
        foreach (var button in buttons)
        {
            button.ButtonPressBegin += HandleButtonPress;
            button.ButtonPressEnd += HandleButtonRelease;
        }
    }

    private void HandleButtonPress()
    {
        if (++ActiveButtons >= requiredButtonsToPress)
        {
            EnableAction?.Invoke();
        }
    }

    private void HandleButtonRelease()
    {
        if (--ActiveButtons <= requiredButtonsToPress)
        {
            DisableAction?.Invoke();
        }
    }
}
