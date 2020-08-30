using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataModel;

public class DeviceController : MonoBehaviour
{
    IDeviceOperations deviceOperations;

    public void OnClick(string name)
    {
        deviceOperations.Click(name);
    }

    public void OnDrag(string name)
    {
        deviceOperations.Drag(name, Input.mousePosition);
    }
}
