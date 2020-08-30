using DataModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private DeviceController deviceController;
    [SerializeField] private SessionController sessionController;

    private void Start()
    {
        TrainingSessionData session = new TrainingSessionData();
        deviceController.SetModel(session);
        sessionController.SetModel(session);
    }
}
