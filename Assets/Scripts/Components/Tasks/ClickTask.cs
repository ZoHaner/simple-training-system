using DataModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(ClickableElement))]
    public class ClickTask : Task
    {
        [Header("Задание:")]
        [SerializeField] ButtonState targetState;
    }
}