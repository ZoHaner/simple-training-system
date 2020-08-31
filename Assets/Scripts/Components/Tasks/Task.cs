using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public abstract class Task : MonoBehaviour
    {
        [Header("Параметры задачи:")]
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