//using DataModel;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// Pадание сдвига объекта вдоль оси
///// </summary>
//public class ShiftAlongAxis : ITargetValue<float>
//{
//    private Axis selectedAxis { get; }
//    private float targetValue { get; }
//    private IOperation<float> operation;


//    public ShiftAlongAxis(Axis axis, float targetValue, IOperation<float> operation)
//    {
//        this.selectedAxis = axis;
//        this.targetValue = targetValue;
//        this.operation = operation;
//    }

//    public bool IsReached(float value)
//    {
//        return operation.Check(targetValue, value);
//    }
//}

public enum Axis
{
    X, Y, Z
}
