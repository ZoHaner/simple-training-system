using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    /// <summary>
    /// Task for shifting an object along one axis
    /// </summary>
    [RequireComponent(typeof(MoveableElement))]
    public class ShiftTask : Task
    {
        [Header("Task:")]
        [SerializeField] private Axis shiftingAxis;
        [SerializeField] private Operator _operator;
        [SerializeField] private float targetValue;

        public Axis ShiftingAxis { get { return shiftingAxis; } }
        public Operator Operator { get { return _operator; } }
        public float TargetValue { get { return targetValue; } }
    }

}
public enum Operator
{
    LessThan,
    MoreThan
}