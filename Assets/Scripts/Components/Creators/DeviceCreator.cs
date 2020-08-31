using Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Создает объекты устройств из префабов
/// </summary>
public class DeviceCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] devicePrefabs;
    private GameObject deviceObject;
    private DeviceController deviceController;

    private void Start()
    {
        DeviceController controller = FindObjectOfType<DeviceController>();
        if(controller != null)
        {
            deviceController = controller;
        }
        else
        {
            throw new NullReferenceException("DeviceCreator : SessionController не найден!");
        }
    }

    public void Create(int index)
    {
        if(index <= devicePrefabs.Length - 1)
        {
            deviceObject = Instantiate(devicePrefabs[index]);
            InteractableElement[] deviceElements = deviceObject.GetComponentsInChildren<InteractableElement>();
            deviceController.LoadNewDevice(deviceElements);
        }
        else
        {
            throw new IndexOutOfRangeException("DeviceCreator : Префаба с таким индексом не существует!");
        }
    }

    public void DestroyDevice()
    {
        Destroy(deviceObject);
    }
}
