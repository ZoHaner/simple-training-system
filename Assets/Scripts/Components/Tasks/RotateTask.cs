using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class RotateTask : Task
    {
        [Header("Задание:")]
        [SerializeField] private Axis rotationAxis;
        [SerializeField] private Operator _operator;
        [SerializeField] private float targetValue;
    }
}