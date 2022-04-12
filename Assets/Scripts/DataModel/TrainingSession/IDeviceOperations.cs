using System.Collections.Generic;
using Components.Interactables;
using DataModel.Elements;
using UnityEngine;

namespace DataModel.TrainingSession
{
    public delegate void ElementParamsChanged(KeyValuePair<string, DeviceElement> element);

    public interface IDeviceOperations
    {
        event ElementParamsChanged OnElementsParamsChanged;

        void LoadNewDevice(InteractableElement[] interactableElements, float startTime);
        void Drag(string deviceName, Vector2 mousePosition);
        void EndDrag(string deviceName, Vector2 mousePosition);
        void Click(string deviceName);
    }
}