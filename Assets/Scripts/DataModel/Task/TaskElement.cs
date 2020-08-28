using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Единица сценария, описывающая элемент, его целевое состояние и порядок выполнения
    /// </summary>
    public class TaskElement
    {
        private Element element;
        private ITask task;
        private int order;
    }
}
