using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public interface IDeviceOperations
    {
        void Drag(string deviceName, Vector2 mouseDelta);
        void Click(string deviceName);
    }
}