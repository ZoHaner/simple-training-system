using Controllers;
using DataModel.TrainingSession;
using UnityEngine;

namespace Components.Initializers
{
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
}
