using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public interface IDeviceOperations
    {
        void TryRotate();
        void TryMove();
        void TryClick();
    }
}