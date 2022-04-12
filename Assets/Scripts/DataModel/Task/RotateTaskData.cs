using Components;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class RotateTaskData : TaskData
    {
        private Axis rotationAxis;
        private IOperation<float> _operator;
        private float targetValue;

        public RotateTaskData(RotateTask rotateTask)
        {
            rotationAxis = rotateTask.RotationAxis;
            Description = rotateTask.Description;

            if (rotateTask.Operator == Operator.LessThan) _operator = new IsLesser<float>();
            else if (rotateTask.Operator == Operator.MoreThan) _operator = new IsBigger<float>();
            else throw new System.Exception();

            targetValue = rotateTask.TargetValue;
        }

        public override bool IsDone(object value)
        {
            if (value is Vector3)
            {
                Vector3 vector = (Vector3)value;
                switch (rotationAxis)
                {
                    case Axis.X:
                        return _operator.Check(vector.x, targetValue);
                    case Axis.Y:
                        return _operator.Check(vector.y, targetValue);
                    case Axis.Z:
                        return _operator.Check(vector.z, targetValue);
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                throw new TypeLoadException($"Type {value.GetType()} cannot be processed!");
            }
        }
    }
}