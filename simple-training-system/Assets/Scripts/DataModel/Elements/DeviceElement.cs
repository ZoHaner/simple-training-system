using System.Collections.Generic;
using DataModel.Elements.Properties;
using DataModel.TrainingSession.Helpers;
using UnityEngine;

namespace DataModel.Elements
{
    /// <summary>
    /// Base class for all device parts
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
