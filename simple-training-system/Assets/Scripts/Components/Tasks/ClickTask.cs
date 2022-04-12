using Components.Interactables;
using DataModel.Elements.Properties;
using UnityEngine;

namespace Components.Tasks
{
    [RequireComponent(typeof(ClickableElement))]
    public class ClickTask : Task
    {
        [Header("Task:")]
        [SerializeField] private ButtonState targetState;

        public ButtonState GetTargetState()
        {
            return targetState;
        }
    }

    
}