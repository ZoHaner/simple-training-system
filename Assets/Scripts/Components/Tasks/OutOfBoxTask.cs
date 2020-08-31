using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    /// <summary>
    /// Задача для перемещение объекта за пределы заданной области
    /// </summary>
    [RequireComponent(typeof(MoveableElement))]
    public class OutOfBoxTask : Task
    {
        [Header("Задание - переместить за пределы области:")]
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