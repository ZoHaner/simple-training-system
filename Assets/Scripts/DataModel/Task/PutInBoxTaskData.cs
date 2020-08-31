using Components;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Данные задачи о перемещении объекта в заданную область
    /// </summary>
    public class PutInBoxTaskData : TaskData
    {
        private Vector3 minValues;
        private Vector3 maxValues;
        private bool[] ignoredAxis;

        public PutInBoxTaskData(PutInBoxTask putInBoxTask)
        {
            minValues = putInBoxTask.GetMinValues();
            maxValues = putInBoxTask.GetMaxValues();
            ignoredAxis = putInBoxTask.GetIgnoredAxis();
            Description = putInBoxTask.Description;
        }

        public override bool IsDone(object value)
        {
            if (value is Vector3)
            {
                Vector3 vector = (Vector3)value;

                bool xInside;
                bool yInside;
                bool zInside;

                if(!ignoredAxis[0])
                    xInside = vector.x > minValues.x && vector.x < maxValues.x;
                else
                    xInside = true;
                
                if (!ignoredAxis[1])
                    yInside = vector.y > minValues.y && vector.y < maxValues.y;
                else
                    yInside = true;
                
                if (!ignoredAxis[2])
                    zInside = vector.z > minValues.z && vector.z < maxValues.z;
                else
                    zInside = true;

                return xInside && yInside && zInside;
            }
            else
            {
                throw new TypeLoadException($"Тип {value.GetType()} не может быть обработан!");
            }
        }
    }
}
