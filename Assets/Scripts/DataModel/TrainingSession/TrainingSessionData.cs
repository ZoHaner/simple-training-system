using Components;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// The class stores information about the training session
    /// </summary>
    public class TrainingSessionData : ISessionCallbacks, IDeviceOperations
    {
        public event ElementParamsChanged OnElementsParamsChanged;
        public event TrainingCompleted OnTrainingCompleted;
        public event TaskError OnTaskError;
        public event TaskCompleted OnTaskCompleted;
        public event MoveToNextTask OnMoveToNextTask;

        private ModelState modelState = ModelState.NotInitialized;
        private int currentTaskIndex;
        private Task[] tasks;
        private Dictionary<string, DeviceElement> deviceElements = new Dictionary<string, DeviceElement>();

        private Vector2 lastMousePosition;
        private float startTime;
        private int errorsCount;

        private InteractableElement[] initialStateDevice;

        #region Session Operations

        /// <summary>
        /// Loading the elements of the new device
        /// </summary>
        /// <param name="interactableElements">Scene objects with InteractableElement component</param>
        public void LoadNewDevice(InteractableElement[] interactableElements, float startTime)
        {
            // Remember for a possible restart
            initialStateDevice = interactableElements;

            this.startTime = startTime;

            // Create a temporary dictionary for found tasks
            Dictionary<Components.Task, DeviceElement> tempTasks = new Dictionary<Components.Task, DeviceElement>();

            foreach (var sceneElement in interactableElements)
            {
                DeviceElement dataElement;

                // Checking if an element is in the list
                if (!deviceElements.TryGetValue(sceneElement.name, out dataElement))
                {
                    dataElement = new DeviceElement();
                    deviceElements.Add(sceneElement.name, dataElement);
                }

                // Converting from scene components to a stored data format
                if(sceneElement is ClickableElement) 
                {
                    ClickableElement clickableElement = (ClickableElement)sceneElement;
                    ButtonProperty bp = new ButtonProperty(clickableElement);
                    dataElement.AddProperty(bp);
                }
                if(sceneElement is MoveableElement)
                {
                    MoveableElement moveableElement = (MoveableElement)sceneElement;
                    PositionProperty pp = new PositionProperty(moveableElement);
                    dataElement.AddProperty(pp);
                }
                if (sceneElement is RotatableElement)
                {
                    RotatableElement rotatableElement = (RotatableElement)sceneElement;
                    RotationProperty rp = new RotationProperty(rotatableElement);
                    dataElement.AddProperty(rp);
                }

                // Looking for tasks in the selected element
                Components.Task[] tasks = sceneElement.gameObject.GetComponents<Components.Task>();

                // And add to the dictionary
                foreach(var taskComponent in tasks)
                {
                    tempTasks.Add(taskComponent, dataElement);
                }
            }

            // Grouping tasks in order of execution
            var groupedTasks = from tempTask in tempTasks
                                group tempTask by tempTask.Key.ExecutionOrder into g
                                orderby g.Key
                                select g;

            tasks = new Task[groupedTasks.Count()];

            int i = 0;
            foreach (var task in groupedTasks)
            {
                Task taskData = new Task();

                foreach (var subTask in task)
                {
                    if(subTask.Key is ClickTask)
                    {
                        ClickTask clickTask = (ClickTask)subTask.Key;
                        ClickTaskData clickTaskData = new ClickTaskData(clickTask);
                        TaskElement taskElement = new TaskElement(subTask.Value, clickTaskData);
                        taskData.TaskElements.Add(taskElement);
                    }
                    else if(subTask.Key is RotateTask)
                    {
                        RotateTask rotateTask = (RotateTask)subTask.Key;
                        RotateTaskData rotateTaskData = new RotateTaskData(rotateTask);
                        TaskElement taskElement = new TaskElement(subTask.Value, rotateTaskData);
                        taskData.TaskElements.Add(taskElement);
                    }
                    else if (subTask.Key is ShiftTask)
                    {
                        ShiftTask shiftTask = (ShiftTask)subTask.Key;
                        ShiftTaskData shiftTaskData = new ShiftTaskData(shiftTask);
                        TaskElement taskElement = new TaskElement(subTask.Value, shiftTaskData);
                        taskData.TaskElements.Add(taskElement);
                    }
                    else if(subTask.Key is PutInBoxTask)
                    {
                        PutInBoxTask putInBoxTask = (PutInBoxTask)subTask.Key;
                        PutInBoxTaskData putInBoxTaskData = new PutInBoxTaskData(putInBoxTask);
                        TaskElement taskElement = new TaskElement(subTask.Value, putInBoxTaskData);
                        taskData.TaskElements.Add(taskElement);
                    }
                    else if (subTask.Key is OutOfBoxTask)
                    {
                        OutOfBoxTask outOfBoxTask = (OutOfBoxTask)subTask.Key;
                        OutOfBoxTaskData outOfBoxTaskData = new OutOfBoxTaskData(outOfBoxTask);
                        TaskElement taskElement = new TaskElement(subTask.Value, outOfBoxTaskData);
                        taskData.TaskElements.Add(taskElement);
                    }
                }

                tasks[i] = taskData;
                i++;
            }

            OnMoveToNextTask(currentTaskIndex + 1, tasks[currentTaskIndex].TaskElements[0].Task.Description);

            modelState = ModelState.Run;
        }

        /// <summary>
        /// Continue session
        /// </summary>
        public void ContinueSession()
        {
            modelState = ModelState.Run;
        }

        /// <summary>
        /// Close and reset the session
        /// </summary>
        public void CloseSession()
        {
            currentTaskIndex = 0;
            tasks = null;
            deviceElements.Clear();
            errorsCount = 0;

            modelState = ModelState.NotInitialized;
        }

        /// <summary>
        /// Restart session with initial parameters
        /// </summary>
        public void RestartSession(float startTime)
        {
            CloseSession();
            LoadNewDevice(initialStateDevice, startTime);

            foreach (var pair in deviceElements)
            {
                OnElementsParamsChanged?.Invoke(pair);
            }

            modelState = ModelState.Run;
        }
        #endregion


        #region Device Operations
        /// <summary>
        /// Handling object repositioning and rotation
        /// </summary>
        /// <param name="deviceName">Scene object name</param>
        /// <param name="mousePosition">Current mouse position</param>
        public void Drag(string deviceName, Vector2 mousePosition)
        {
            if (modelState != ModelState.Run) return;

            if (lastMousePosition != Vector2.zero)
            {
                DragElement(deviceName, mousePosition - lastMousePosition);
            }

            lastMousePosition = mousePosition;
        }

        /// <summary>
        /// Handling the end of changing the position and rotation of the object
        /// </summary>
        /// <param name="deviceName">Scene object name</param>
        /// <param name="mousePosition">Current mouse position</param>
        public void EndDrag(string deviceName, Vector2 mousePosition)
        {
            if (modelState != ModelState.Run) return;

            if (lastMousePosition != Vector2.zero)
            {
                DragElement(deviceName, mousePosition - lastMousePosition);
            }

            lastMousePosition = Vector2.zero;

            // Checking for completeness of the task and exercise
            if(TaskChecker.CheckIfTaskIsDone(tasks[currentTaskIndex]))
            {
                if(currentTaskIndex < tasks.Length - 1)
                {
                    currentTaskIndex++;
                    OnTaskCompleted?.Invoke();
                    OnMoveToNextTask?.Invoke(currentTaskIndex + 1, tasks[currentTaskIndex].TaskElements[0].Task.Description);
                }
                else
                {
                    OnTrainingCompleted?.Invoke(startTime, errorsCount);
                }
            }
        }

        /// <summary>
        /// Handling clicking on an element
        /// </summary>
        public void Click(string deviceName)
        {
            if (modelState != ModelState.Run) return;

            DeviceElement deviceElement;
            if (deviceElements.TryGetValue(deviceName, out deviceElement))
            {
                bool elementInTask = TaskChecker.CheckIfElementInTask(deviceElement, tasks[currentTaskIndex]);
                if (!elementInTask)
                {
                    OnTaskError?.Invoke();
                    modelState = ModelState.Paused;
                    errorsCount++;
                    return;
                }

                deviceElement.Click();
                OnElementsParamsChanged(new KeyValuePair<string, DeviceElement>(deviceName, deviceElements[deviceName]));

                // Checking for completeness of the task and exercise
                if (TaskChecker.CheckIfTaskIsDone(tasks[currentTaskIndex]))
                {
                    if (currentTaskIndex < tasks.Length - 1)
                    {
                        currentTaskIndex++;
                        OnTaskCompleted?.Invoke();
                        OnMoveToNextTask?.Invoke(currentTaskIndex + 1, tasks[currentTaskIndex].TaskElements[0].Task.Description);
                    }
                    else
                    {
                        OnTrainingCompleted?.Invoke(startTime, errorsCount);
                        modelState = ModelState.Finished;
                    }
                }
            }
        }

        private void DragElement(string deviceName, Vector2 deltaPos)
        {
            DeviceElement deviceElement;
            if (deviceElements.TryGetValue(deviceName, out deviceElement))
            {
                // Before drag, we check if this element needs to be affected
                bool elementInTask = TaskChecker.CheckIfElementInTask(deviceElement, tasks[currentTaskIndex]);
                if(!elementInTask) 
                {
                    OnTaskError?.Invoke();
                    modelState = ModelState.Paused;
                    errorsCount++;
                    return;
                }

                deviceElement.Drag(deltaPos);
                OnElementsParamsChanged(new KeyValuePair<string, DeviceElement>(deviceName, deviceElements[deviceName]));
            }
        }


        #endregion
    }

    public enum ModelState
    { 
        NotInitialized,
        Paused,
        Run,
        Finished
}
}