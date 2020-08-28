using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public interface IOperation<T>
    {
        bool Check(T baseValue, T secondValue);
    }
}