using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Преобразователь движения мыши в изменение позиции и вращения объекта
/// </summary>
public class ActionConvertor
{
    /// <summary>
    /// Преобразование движения мыши в изменение позиции
    /// </summary>
    /// <param name="mouseDelta"></param>
    /// <returns></returns>
    public static Vector3 ConvertToDeltaPosition(Vector2 mouseDelta)
    {
        float deltaX = mouseDelta.x * 0.002f;
        float deltaY = mouseDelta.y * 0.001f;
        float deltaZ = mouseDelta.y * 0.001f;
        return new Vector3(deltaX, deltaY, deltaZ);
    }

    /// <summary>
    /// Преобразование движения мыши в изменение вращения объекта
    /// </summary>
    /// <param name="mouseDelta"></param>
    /// <returns></returns>
    public static Vector3 ConvertToDeltaRotation(Vector2 mouseDelta)
    {
        float deltaX = mouseDelta.y * 0.1f;
        float deltaY = mouseDelta.x * 0.1f;
        float deltaZ = mouseDelta.y * 0.2f;
        return new Vector3(deltaX, deltaY, deltaZ);
    }
}
