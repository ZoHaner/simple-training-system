﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
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
    }
}
