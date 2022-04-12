using System;
using Components.Tasks;
using DataModel.Elements.Properties;
using DataModel.Task.TargetStates;

namespace DataModel.Task
{
    public class ClickTaskData : TaskData
    {
        private ButtonState targetState;

        public ClickTaskData(ButtonState targetState)
        {
            this.targetState = targetState;
        }

        public ClickTaskData(ClickTask clickTask)
        {
            this.targetState = clickTask.GetTargetState();
            Description = clickTask.Description;
        }

        public override bool IsDone(object value)
        {
            if(value is ButtonState)
            {
                var state = (ButtonState)value;
                if(state == targetState)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else throw new TypeLoadException($"Type {value.GetType()} cannot be processed!");
        }
    }
}