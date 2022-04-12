using Components.Interactables;
using DataModel.Task;
using UnityEngine;

namespace Components.Tasks
{
    [RequireComponent(typeof(RotatableElement))]
    public class RotateTask : Task
    {
        [Header("Task:")]
        [SerializeField] private Axis rotationAxis;
        [SerializeField] private Operator _operator;
        [SerializeField] private float targetValue;

        public Axis RotationAxis { get { return rotationAxis; } }
        public Operator Operator { get { return _operator; } }
        public float TargetValue { get { return targetValue; } }
    }
}