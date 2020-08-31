using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Проверка на нахождение точки внутри заданной области
    /// </summary>
    public class IsInside : IOperation<Vector3[]>
    {
        public bool Check(Vector3[] baseValue, Vector3[] secondValue)
        {
            Vector3 obj = baseValue[0];
            Vector3 minValues = secondValue[0];
            Vector3 maxValues = secondValue[1];

            if (obj.x > minValues.x && obj.x < maxValues.x &&
                obj.y > minValues.y && obj.y < maxValues.y &&
                obj.z > minValues.y && obj.z < maxValues.z)
            {
                return true;
            }
            else
                return false;
        }
    }
}