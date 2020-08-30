using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Класс хранит информацию о тренировочной сессии
    /// </summary>
    public class TrainingSessionData : ISessionCallbacks, ISessionOperations, IDeviceOperations
    {
        public event ElementsParamsChanged OnElementsParamsChanged;
        public event TrainingFinished OnTrainingFinished;
        public event TrainingErrorAction OnTrainingErrorAction;

        private int currentTaskIndex;
        private Task[] tasks;
        private Dictionary<string, DeviceElement> deviceElements = new Dictionary<string, DeviceElement>();
        
        private float startTime;
        private int errorsCount;

        public void StartSession(float startTime)
        {
            this.startTime = startTime;
        }

        #region Session Operations
        /// <summary>
        /// Загружаем элементы нового устройства
        /// </summary>
        /// <param name="interactableElements">Объекты сцены с компонентом InteractableElement</param>
        public void LoadNewDevice(InteractableElement[] interactableElements)
        {
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

            }
            // Парсим компоненты и заполняем tasks
        }
        
        public void ClearSessionData()
        {
            currentTaskIndex = 0;
            tasks = null;
            deviceElements.Clear();
            errorsCount = 0;
        }
        #endregion

        #region Device Operations
        public void Drag(string deviceName, Vector2 mouseDelta)
        {
            throw new System.NotImplementedException();
        }

        public void Click(string deviceName)
        {
            throw new System.NotImplementedException();
        }

        public void EndDrag(string deviceName, Vector2 mousePosition)
        {
            throw new System.NotImplementedException();
        }
        #endregion


    }
}