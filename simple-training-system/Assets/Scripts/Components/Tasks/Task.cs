using UnityEngine;

namespace Components.Tasks
{
    public abstract class Task : MonoBehaviour
    {
        [Header("Task parameters:")]
        [SerializeField] private uint executionOrder;
        [TextArea]
        [SerializeField] private string description;

        public uint ExecutionOrder
        {
            get
            {
                return executionOrder;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }
    }
}