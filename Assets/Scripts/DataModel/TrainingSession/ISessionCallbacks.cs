using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public delegate void TrainingFinished(int time, int errors);
    public delegate void TaskError();
    public delegate void TaskCompleted(int order, string description);

    public interface ISessionCallbacks
    {
        event TrainingFinished OnTrainingFinished;
        event TaskError OnTaskError;
        event TaskCompleted OnTaskCompleted;
    }
}
