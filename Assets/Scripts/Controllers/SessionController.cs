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
        model.OnTrainingFinished += Model_OnTrainingFinished;
    }

    private void Model_OnTrainingFinished(int time, int errors)
    {
        Debug.Log($"Model_OnTrainingFinished : Time - {time}. Errors - {errors}");
    }

    private void Model_OnTaskCompleted(int order, string description)
    {
        Debug.Log($"Model_OnTaskCompleted : Time - {order}. Errors - {description}");
    }

    private void Model_OnTrainingErrorAction()
    {
        Debug.Log($"Model_OnTrainingErrorAction");
    }
}
