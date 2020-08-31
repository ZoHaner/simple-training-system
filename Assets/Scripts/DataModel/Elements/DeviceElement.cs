using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Базовый класс для всех частей устройства
    /// </summary>
    public class DeviceElement
    {
        public List<IProperty> Properties { get; private set; } = new List<IProperty>();
        
        public void AddProperty(IProperty property)
        {
            Properties.Add(property);
        }

        public void Drag(Vector3 deltaPos)
        {
            foreach (var prop in Properties)
            {
                if(prop is PositionProperty)
                {
                    PositionProperty positionProperty = (PositionProperty)prop;
                    positionProperty.Move(ActionConvertor.ConvertToDeltaPosition(deltaPos));
                }
                else if(prop is RotationProperty)
                {
                    RotationProperty rotationProperty = (RotationProperty)prop;
                    rotationProperty.Rotate(ActionConvertor.ConvertToDeltaRotation(deltaPos));
                }
            }
        }

        public void Click()
        {
            foreach (var prop in Properties)
            {
                if (prop is ButtonProperty)
                {
                    ButtonProperty buttonProperty = (ButtonProperty)prop;
                    buttonProperty.Switch();
                }
            }
        }
    }
}
