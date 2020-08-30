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
        private Dictionary<string, Element> deviceElements;
        
        private float startTime;
        private int errorsCount;

        public TrainingSessionData(float startTime)
        {
            this.startTime = startTime;
        }

        #region Session Operations
        /// <summary>
        /// Загружаем элементы нового устройства
        /// </summary>
        /// <param name="deviceElements"></param>
        public void LoadNewDevice(Object[] deviceElements)
        {
            ClearSessionData();

            // Парсим компоненты и заполняем deviceElements и tasks
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