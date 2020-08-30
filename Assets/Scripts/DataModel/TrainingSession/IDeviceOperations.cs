using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public delegate void ElementsParamsChanged();

    public interface IDeviceOperations
    {
        event ElementsParamsChanged OnElementsParamsChanged;

        void Drag(string deviceName, Vector2 mousePosition);
        void EndDrag(string deviceName, Vector2 mousePosition);
        void Click(string deviceName);
    }
}