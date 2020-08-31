using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Класс для проверки возможности работы с выбранными элементами
    /// </summary>
    public class TaskChecker
    {
        /// <summary>
        /// Проверка на вхождение объекта в текущую задачу
        /// </summary>
        /// <param name="deviceElement">Выбранный элемент</param>
        /// <param name="task">Текущая задача</param>
        public static bool CheckIfElementInTask(DeviceElement deviceElement, Task task)
        {
            foreach (var taskElement in task.TaskElements)
            {
                // Смотрим только по невыполненным задачам
                if(!taskElement.IsDone)
                {
                    if (taskElement.Element == deviceElement)
                        return true;
                }
            }

            return false;
        }
    }
}