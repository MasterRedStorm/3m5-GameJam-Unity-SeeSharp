using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonColors
{
    public Color normal;
    public Color highlighted;
    public Color pressed;
    public Color selected;
    public Color disabled;
}

[CreateAssetMenu(fileName = "ButtonColorScheme", menuName = "ScriptableObjects/ButtonColorScheme", order = 1)]
public class ButtonColorScheme : ScriptableObject
{
    //public ButtonColors normal;
    //public ButtonColors active;
    public ColorBlock normal;
    public ColorBlock active;
}