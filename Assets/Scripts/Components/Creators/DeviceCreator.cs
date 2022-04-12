using System;
using Components.Interactables;
using Controllers;
using UnityEngine;

namespace Components.Creators
{
    /// <summary>
    /// Creates device object from prefab
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
                throw new NullReferenceException("DeviceCreator : SessionController wasn't found!");
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
                throw new IndexOutOfRangeException($"DeviceCreator : Prefab with index '{index}' doesn't exist!");
            }
        }

        public void DestroyDevice()
        {
            Destroy(deviceObject);
        }
    }
}
