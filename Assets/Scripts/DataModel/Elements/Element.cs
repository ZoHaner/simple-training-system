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
        IProperty[] properties;

        public Element(IProperty[] properties)
        {
            this.properties = properties;
        }
    }
}
