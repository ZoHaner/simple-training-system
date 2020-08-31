using Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public class ClickTaskData : ITask
    {
        private ButtonState targetState;

        public ClickTaskData(ButtonState targetState)
        {
            this.targetState = targetState;
        }

        public ClickTaskData(ClickTask clickTask)
        {
            this.targetState = clickTask.GetTargetState();
        }
    }
}