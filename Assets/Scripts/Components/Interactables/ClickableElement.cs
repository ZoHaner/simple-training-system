using DataModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableElement : InteractableElement
{
    [SerializeField] private ButtonState buttonState;

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

    public ButtonState GetButtonState()
    {
        return buttonState;
    }

    private void OnMouseUp()
    {
        deviceController.OnClick(gameObject.name);
    }
}
