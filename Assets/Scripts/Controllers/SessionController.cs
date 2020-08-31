using DataModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionController : MonoBehaviour
{
    private ISessionCallbacks model;

    public void SetModel(ISessionCallbacks model)
    {
        this.model = model;

        model.OnTaskError += Model_OnTrainingErrorAction;
        model.OnTaskCompleted += Model_OnTaskCompleted;
        model.OnMoveToNextTask += Model_OnMoveToNextTask;
        model.OnTrainingCompleted += Model_OnTrainingFinished;
    }

    private void Model_OnMoveToNextTask(int order, string description)
    {
        Debug.Log($"Model_OnMoveToNextTask : Next #{order}. Task - {description}");
    }

    private void Model_OnTrainingFinished(float startTime, int errors)
    {
        Debug.Log($"Model_OnTrainingFinished : Time - {Time.time - startTime}. Errors - {errors}");
    }

    private void Model_OnTaskCompleted()
    {
        Debug.Log($"Model_OnTaskCompleted");
    }

    private void Model_OnTrainingErrorAction()
    {
        Debug.Log($"Model_OnTrainingErrorAction");
    }
}
