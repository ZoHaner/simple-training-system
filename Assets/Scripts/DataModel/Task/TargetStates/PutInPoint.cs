using DataModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    [System.Serializable]
    public class PutInPoint : ITargetValue<Vector3>
    {
        public Vector3 TargetValue { get; set; }
        public float Radius { get; set; }

        public bool IsReached(Vector3 value)
        {
            float distance = Vector3.Distance(TargetValue, value);
            if (distance < Radius)
            {
                return true;
            }
            else
                return false;
        }
    }
}