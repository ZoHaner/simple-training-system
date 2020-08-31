using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class TaskElement
    {
        public DeviceElement Element { get; private set; }
        public TaskData Task { get; private set; }
        public bool IsDone { get; private set; }

        public TaskElement(DeviceElement deviceElement, TaskData task)
        {
            Element = deviceElement;
            Task = task;
            IsDone = false;
        }

        public bool CheckIsDone()
        {
            switch (Task)
            {
                case ClickTaskData d:
                    IsDone = d.IsDone(GetButtonProperty().ButtonState);
                    break;
                case ShiftTaskData s:
                    IsDone = s.IsDone(GetPositionProperty().Position);
                    break;
                case RotateTaskData r:
                    IsDone = r.IsDone(GetRotationProperty().Rotation);
                    break;
                case PutInBoxTaskData p:
                    IsDone = p.IsDone(GetPositionProperty().Position);
                    break;
                case OutOfBoxTaskData o:
                    IsDone = o.IsDone(GetPositionProperty().Position);
                    break;
                default:
                    throw new TypeLoadException($"Тип {Task.GetType()} не может быть обработан!");
            }

            return IsDone;
        }

        private ButtonProperty GetButtonProperty()
        {
            foreach (var prop in Element.Properties)
            {
                if (prop is ButtonProperty)
                {
                    ButtonProperty buttonProperty = (ButtonProperty)prop;
                    return buttonProperty;
                }
            }

            throw new System.Exception("У элемента нет свойства ButtonProperty!");
        }

        private PositionProperty GetPositionProperty()
        {
            foreach (var prop in Element.Properties)
            {
                if (prop is PositionProperty)
                {
                    PositionProperty positionProperty = (PositionProperty)prop;
                    return positionProperty;
                }
            }

            throw new System.Exception("У элемента нет свойства PositionProperty!");
        }

        private RotationProperty GetRotationProperty()
        {
            foreach (var prop in Element.Properties)
            {
                if (prop is RotationProperty)
                {
                    RotationProperty rotationProperty = (RotationProperty)prop;
                    return rotationProperty;
                }
            }

            throw new System.Exception("У элемента нет свойства RotationProperty!");
        }
    }
}