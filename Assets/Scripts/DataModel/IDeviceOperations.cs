using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public interface IDeviceOperations
    {
        void TryRotate(string deviceName, Vector2 mouseDelta);
        void TryMove(string deviceName, Vector2 mouseDelta);
        void TryClick(string deviceName);
    }
}