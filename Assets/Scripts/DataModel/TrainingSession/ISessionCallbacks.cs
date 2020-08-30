using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataModel
{
    public delegate void ElementsParamsChanged();
    public delegate void TrainingFinished(int time, int errors);
    public delegate void TrainingErrorAction();

    public interface ISessionCallbacks
    {
        event ElementsParamsChanged OnElementsParamsChanged;

        event TrainingFinished OnTrainingFinished;

        event TrainingErrorAction OnTrainingErrorAction;
    }
}
