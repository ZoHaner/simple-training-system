using Components;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Класс хранит информацию о тренировочной сессии
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
        /// Загружаем элементы нового устройства
        /// </summary>
        /// <param name="interactableElements">Объекты сцены с компонентом InteractableElement</param>
        public void LoadNewDevice(InteractableElement[] interactableElements, float startTime)
        {
            // Запоминаем для возможного перезапуска
            initialStateDevice = interactableElements;

            this.startTime = startTime;

            // Создаем временный словарь для найденных задач
            Dictionary<Components.Task, DeviceElement> tempTasks = new Dictionary<Components.Task, DeviceElement>();

            foreach (var sceneElement in interactableElements)
            {
                DeviceElement dataElement;

                // Проверяем, наличие элемента в списке
                if (!deviceElements.TryGetValue(sceneElement.name, out dataElement))
                {
                    dataElement = new DeviceElement();
                    deviceElements.Add(sceneElement.name, dataElement);
                }

                // Преобразуем из компонентов сцены в хранимый формат данных
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

                // Ищем задачи в выбранном элементе
                Components.Task[] tasks = sceneElement.gameObject.GetComponents<Components.Task>();

                // И добавляем в словарь
                foreach(var taskComponent in tasks)
                {
                    tempTasks.Add(taskComponent, dataElement);
                }
            }

            // Группируем задачи по порядку выполнения
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
        /// Продолжаем сессию
        /// </summary>
        public void ContinueSession()
        {
            modelState = ModelState.Run;
        }

        /// <summary>
        /// Обнуляем сессию
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
        /// Перезагружаем сессию с начальными параметрами
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
        /// Обработка изменения положения и вращения объекта
        /// </summary>
        /// <param name="deviceName">Имя объекта на сцене</param>
        /// <param name="mousePosition">Текущая позиция мыши</param>
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
        /// Обработка окончания изменения положения и вращения объекта
        /// </summary>
        /// <param name="deviceName">Имя объекта на сцене</param>
        /// <param name="mousePosition">Текущая позиция мыши</param>
        public void EndDrag(string deviceName, Vector2 mousePosition)
        {
            if (modelState != ModelState.Run) return;

            if (lastMousePosition != Vector2.zero)
            {
                DragElement(deviceName, mousePosition - lastMousePosition);
            }

            lastMousePosition = Vector2.zero;

            // Проверка на завершенность задачи и упражнения
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
        /// Обработка нажатия на элемент
        /// </summary>
        /// <param name="deviceName"></param>
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

                // Проверка на завершенность задачи и упражнения
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
                // Перед Drag проверяем, на этот ли элемент нужно воздействовать
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