using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour
{
    public Action ButtonPressBegin;
    public Action ButtonPressEnd;

    public void Activate() => ButtonPressBegin?.Invoke();

    public void Deactivate() => ButtonPressEnd?.Invoke();
}
