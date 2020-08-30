using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public interface ISessionOperations
    {
        void LoadNewDevice(Object[] deviceElements);
        void ClearSessionData();
    }
}
