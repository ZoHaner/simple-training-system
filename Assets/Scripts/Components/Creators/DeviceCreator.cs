using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] devicePrefabs;

    public void Create(int index)
    {
        if(index <= devicePrefabs.Length - 1)
        {
            var device = Instantiate(devicePrefabs[index]);
        }
        else
        {
            throw new IndexOutOfRangeException("DeviceCreator : Префаба с таким индексом не существует!");
        }
    }
}
