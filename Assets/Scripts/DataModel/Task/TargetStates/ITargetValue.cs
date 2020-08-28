using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Базовый класс для целевого состояния объекта
    /// </summary>
    public interface ITargetValue<T> : ITask
    {
        bool IsReached(T value);
    }
}