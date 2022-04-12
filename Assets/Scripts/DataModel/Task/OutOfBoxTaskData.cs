using System;
using Components.Tasks;
using DataModel.Task.TargetStates;
using UnityEngine;

namespace DataModel.Task
{
    /// <summary>
    /// Task data about moving an object outside the area
    /// </summary>
    public class OutOfBoxTaskData : TaskData
    {
        private Vector3 minValues;
        private Vector3 maxValues;
        private bool[] ignoredAxis;


        public OutOfBoxTaskData(OutOfBoxTask outOfBoxTask)
        {
            minValues = outOfBoxTask.GetMinValues();
            maxValues = outOfBoxTask.GetMaxValues();
            ignoredAxis = outOfBoxTask.GetIgnoredAxis();
            Description = outOfBoxTask.Description;
        }

        public override bool IsDone(object value)
        {
            if (value is Vector3)
            {
                Vector3 vector = (Vector3)value;

                bool xOutside;
                bool yOutside;
                bool zOutside;

                if (!ignoredAxis[0])
                    xOutside = vector.x < minValues.x || vector.x > maxValues.x;
                else
                    xOutside = true;

                if (!ignoredAxis[1])
                    yOutside = vector.y < minValues.y || vector.y > maxValues.y;
                else
                    yOutside = true;

                if (!ignoredAxis[2])
                    zOutside = vector.z < minValues.z || vector.z > maxValues.z;
                else
                    zOutside = true;

                return xOutside && yOutside && zOutside;
            }
            else
            {
                throw new TypeLoadException($"Type {value.GetType()} cannot be processed!");
            }
        }
    }
}