using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class IsLesser<T> : IOperation<T> where T : IComparable<T>
    {
        public bool Check(T baseValue, T secondValue)
        {
            int res = baseValue.CompareTo(secondValue);
            return res < 0;
        }
    }
}