using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Класс хранит информацию о тренировочной сессии
    /// </summary>
    public class TrainingSession
    {
        private List<TaskElement> task;
        private float startTime;
        private int errorsCount;

        public TrainingSession(float startTime, List<TaskElement> task)
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