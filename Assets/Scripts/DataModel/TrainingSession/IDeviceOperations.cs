using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public delegate void ElementParamsChanged(KeyValuePair<string, DeviceElement> element);

    public interface IDeviceOperations
    {
        event ElementParamsChanged OnElementsParamsChanged;

        void LoadNewDevice(InteractableElement[] interactableElements);
        void Drag(string deviceName, Vector2 mousePosition);
        void EndDrag(string deviceName, Vector2 mousePosition);
        void Click(string deviceName);
    }
}