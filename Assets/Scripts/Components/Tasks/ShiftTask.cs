using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(MoveableElement))]
    public class ShiftTask : Task
    {
        [Header("Задание:")]
        [SerializeField] private Axis shiftingAxis;
        [SerializeField] private Operator _operator;
        [SerializeField] private float targetValue;
    }

    public enum Operator
    {
        LessThan, 
        MoreThan
    }
}