using System.Collections.Generic;

namespace DataModel.Task
{
    /// <summary>
    /// A script unit that describes an element, its target state, and execution order
    /// </summary>
    public class Task
    {
        public List<TaskElement> TaskElements { get; set; } = new List<TaskElement>();
    }
}
