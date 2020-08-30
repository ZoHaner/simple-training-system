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
    
    private SessionController sessionController;

    private void Start()
    {
        SessionController controller = FindObjectOfType<SessionController>();
        if(controller != null)
        {
            sessionController = controller;
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
            GameObject device = Instantiate(devicePrefabs[index]);
            InteractableElement[] deviceElements = device.GetComponentsInChildren<InteractableElement>();
            sessionController.LoadNewDevice(deviceElements);
        }
        else
        {
            throw new IndexOutOfRangeException("DeviceCreator : Префаба с таким индексом не существует!");
        }
    }
}
