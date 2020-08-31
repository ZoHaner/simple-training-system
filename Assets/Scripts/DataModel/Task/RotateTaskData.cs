using Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class RotateTaskData : ITask
    {
        private Axis rotationAxis;
        private Operator _operator;
        private float targetValue;

        public RotateTaskData(RotateTask rotateTask)
        {
            rotationAxis = rotateTask.RotationAxis;
            _operator = rotateTask.Operator;
            targetValue = rotateTask.TargetValue;
        }
    }
}