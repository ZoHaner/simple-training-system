using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableElement : MonoBehaviour, IInteractable
{
    private DeviceController deviceController;

    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minY, maxY;
    [SerializeField] private float minZ, maxZ;

    private void Start()
    {
        var controller = FindObjectOfType<DeviceController>();
        if (controller != null)
        {
            deviceController = controller;
        }
        else
        {
            Debug.LogError($"MoveableElement : DeviceController не найден");
        }
    } 

    private void OnMouseDrag()
    {
        deviceController.OnDrag(gameObject.name);
    }

    private void OnMouseDown()
    {
        deviceController.OnEndDrag(gameObject.name);
    }
}
