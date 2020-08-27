using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Кнопка с 2-мя состояниями - вкл/выкл
    /// </summary>
    public class Button : Element
    {
        ButtonState state;
    }

    public enum ButtonState 
    { 
        On,
        Off
    }
}