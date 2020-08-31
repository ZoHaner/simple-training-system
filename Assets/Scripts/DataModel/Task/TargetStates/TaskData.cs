using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public abstract class TaskData
    {
        public string Description { get; set; }
        public abstract bool IsDone(object value);
    }
}