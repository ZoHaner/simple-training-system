using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class TaskElement
    {
        public DeviceElement Element { get; private set; }
        public ITask Task { get; private set; }
        public bool IsDone { get; private set; }

        public TaskElement(DeviceElement deviceElement, ITask task)
        {
            Element = deviceElement;
            Task = task;
            IsDone = false;
        }

        public void MarkAsDone()
        {
            IsDone = true;
        }
    }
}