using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Класс хранит информацию о тренировочной сессии
    /// </summary>
    public class TrainingSession
    {
        private List<TaskElement> task;
        private float time;
        private int errorsCount;
    }
}