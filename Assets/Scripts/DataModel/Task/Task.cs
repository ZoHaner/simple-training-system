using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// A script unit that describes an element, its target state, and execution order
    /// </summary>
    public class Task
    {
        public List<TaskElement> TaskElements { get; set; } = new List<TaskElement>();
    }
}
