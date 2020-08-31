using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    /// <summary>
    /// Задача для установки объекта в заданную область
    /// </summary>
    [RequireComponent(typeof(MoveableElement))]
    public class PutInBoxTask : Task
    {
        [Header("Задание - поместить в область с габаритами:")]
        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float minY;
        [SerializeField] private float maxY;
        [SerializeField] private float minZ;
        [SerializeField] private float maxZ;
        [SerializeField] private bool ignoreX;
        [SerializeField] private bool ignoreY;
        [SerializeField] private bool ignoreZ;

        public bool[] GetIgnoredAxis()
        {
            return new bool[3] { ignoreX, ignoreY, ignoreZ };
        }

        public Vector3 GetMinValues()
        {
            return new Vector3(minX, minY, minZ);
        }

        public Vector3 GetMaxValues()
        {
            return new Vector3(maxX, maxY, maxZ);
        }
    }
}