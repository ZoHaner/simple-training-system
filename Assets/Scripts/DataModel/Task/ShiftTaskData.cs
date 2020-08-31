using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;

namespace DataModel
{
    public class ShiftTaskData : ITask
    {
        private Axis shiftingAxis;
        private Operator _operator;
        private float targetValue;

        public ShiftTaskData(ShiftTask shiftTask)
        {
            shiftingAxis = shiftTask.ShiftingAxis;
            _operator = shiftTask.Operator;
            targetValue = shiftTask.TargetValue;
        }
    }
}