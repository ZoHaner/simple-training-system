using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonProperty : IProperty
{
    public ButtonState ButtonState { get; private set; }

    public ButtonProperty(ButtonState initState)
    {
        ButtonState = initState;
    }

    public void Switch()
    {
        if (ButtonState == 0) ButtonState = (ButtonState)1;
        else ButtonState = 0;
    }
}

public enum ButtonState
{
    Off = 0,
    On = 1
}