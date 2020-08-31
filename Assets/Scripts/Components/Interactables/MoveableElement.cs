using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableElement : InteractableElement
{
    private DeviceController deviceController;
    private Vector3 startPosition;

    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minY, maxY;
    [SerializeField] private float minZ, maxZ;

    private void Awake()
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

        startPosition = transform.position;
    } 

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }

    public bool[] GetLocks()
    {
        return new bool[3] { lockX, lockY, lockZ };
    }

    public Vector3 GetMinValues()
    {
        return new Vector3(minX, minY, minZ);
    }

    public Vector3 GetMaxValues()
    {
        return new Vector3(maxX, maxY, maxZ);
    }

    private void OnMouseDrag()
    {
        deviceController.OnDrag(gameObject.name);
    }

    private void OnMouseUp()
    {
        deviceController.OnEndDrag(gameObject.name);
    }
}
