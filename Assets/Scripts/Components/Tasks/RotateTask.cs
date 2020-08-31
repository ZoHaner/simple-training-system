using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(RotatableElement))]
    public class RotateTask : Task
    {
        [Header("Задание:")]
        [SerializeField] private Axis rotationAxis;
        [SerializeField] private Operator _operator;
        [SerializeField] private float targetValue;

        public Axis RotationAxis { get { return rotationAxis; } }
        public Operator Operator { get { return _operator; } }
        public float TargetValue { get { return targetValue; } }
    }
}