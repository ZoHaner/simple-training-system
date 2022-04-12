using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;
using System;

namespace DataModel
{
    public class ShiftTaskData : TaskData
    {
        private Axis shiftingAxis;
        private IOperation<float> _operator;
        private float targetValue;

        public ShiftTaskData(ShiftTask shiftTask)
        {
            shiftingAxis = shiftTask.ShiftingAxis;
            Description = shiftTask.Description;

            if (shiftTask.Operator == Operator.LessThan) _operator = new IsLesser<float>();
            else if (shiftTask.Operator == Operator.MoreThan) _operator = new IsBigger<float>();
            else throw new System.Exception();
            
            targetValue = shiftTask.TargetValue;
        }

        public override bool IsDone(object value)
        {
            if(value is Vector3)
            {
                Vector3 vector = (Vector3)value;
                switch (shiftingAxis)
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