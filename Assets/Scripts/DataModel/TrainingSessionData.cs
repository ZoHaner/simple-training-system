using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Класс хранит информацию о тренировочной сессии
    /// </summary>
    public class TrainingSessionData
    {
        private Task[] tasks;
        private float startTime;
        private int errorsCount;

        public TrainingSessionData(float startTime, Task[] task)
        {
            this.startTime = startTime;
            this.tasks = task;
        }

        public Task GetCurrentTask()
        {
            return null;
        }
    }
}