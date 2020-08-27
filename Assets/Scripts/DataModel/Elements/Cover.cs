using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DataModel
{
    /// <summary>
    /// Крышка устройства с 2-мя состояниями - открыта/закрыта
    /// </summary>
    public class Cover : Element
    {
        CoverState state;
        float angle;
    }

    public enum CoverState
    {
        Opened,
        Closed
    }
}
