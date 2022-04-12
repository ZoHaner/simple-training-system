namespace DataModel.TrainingSession
{
    public delegate void TrainingCompleted(float time, int errors);
    public delegate void TaskError();
    public delegate void TaskCompleted();
    public delegate void MoveToNextTask(int order, string description);


    public interface ISessionCallbacks
    {
        event TrainingCompleted OnTrainingCompleted;
        event TaskError OnTaskError;
        event TaskCompleted OnTaskCompleted;
        event MoveToNextTask OnMoveToNextTask;

        void ContinueSession();
        void CloseSession();
        void RestartSession(float startTime);
    }
}
