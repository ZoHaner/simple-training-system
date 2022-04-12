namespace DataModel.Task.TargetStates
{
    public abstract class TaskData
    {
        public string Description { get; set; }
        public abstract bool IsDone(object value);
    }
}