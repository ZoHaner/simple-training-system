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
    }
}
