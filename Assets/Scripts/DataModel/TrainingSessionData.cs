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
        private List<TaskElement> task;
        private float startTime;
        private int errorsCount;

        public TrainingSessionData(float startTime, List<TaskElement> task)
        {
            this.startTime = startTime;
            this.task = task;
        }

        public TaskElement GetCurrentTask()
        {
            return null;
        }
    }
}