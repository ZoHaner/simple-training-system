using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableElement : InteractableElement
{
    private DeviceController deviceController;

    private void Start()
    {
        var controller = FindObjectOfType<DeviceController>();
        if (controller != null)
        {
            deviceController = controller;
        }
        else
        {
            Debug.LogError($"RotatableElement : DeviceController не найден");
        }
    }

    private void OnMouseUp()
    {
        deviceController.OnClick(gameObject.name);
    }
}
