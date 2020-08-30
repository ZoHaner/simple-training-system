using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    /// <summary>
    /// Базовый класс для всех частей устройства
    /// </summary>
    public class Element
    {
        public IProperty[] Properties { get; set; }

        public Element(IProperty[] properties)
        {
            this.Properties = properties;
        }
    }
}
