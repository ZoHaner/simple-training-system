using Components.Interactables;
using UnityEngine;

namespace Components.Tasks
{
    /// <summary>
    /// Task to move an object outside a given area
    /// </summary>
    [RequireComponent(typeof(MoveableElement))]
    public class OutOfBoxTask : Task
    {
        [Header("Task - move out of area:")]
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