using DataModel.Elements;

namespace DataModel.TrainingSession.Helpers
{
    public class TaskChecker
    {
        /// <summary>
        /// Checking if an object is included in the current task
        /// </summary>
        /// <param name="deviceElement">Selected element</param>
        /// <param name="task">Current task</param>
        public static bool CheckIfElementInTask(DeviceElement deviceElement, Task.Task task)
        {
            foreach (var taskElement in task.TaskElements)
            {
                // Look only at outstanding tasks
                if (!taskElement.IsDone)
                {
                    if (taskElement.Element == deviceElement)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checking the completion of a Task
        /// </summary>
        /// <param name="task">Task from task array</param>
        public static bool CheckIfTaskIsDone(Task.Task task)
        {
            int isDoneCount = 0;
            foreach (var taskElement in task.TaskElements)
            {
                if (taskElement.CheckIsDone())
                {
                    isDoneCount++;
                }
            }

            if (task.TaskElements.Count == isDoneCount)
                return true;
            else
                return false;
        }
    }
}