using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class TaskElement
    {
        private DeviceElement element;
        private ITask task;
        private bool isDone;

        public TaskElement(DeviceElement deviceElement, ITask task)
        {
            element = deviceElement;
            this.task = task;
            isDone = false;
        }
    }
}