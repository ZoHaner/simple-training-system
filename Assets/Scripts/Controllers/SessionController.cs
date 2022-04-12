using DataModel.TrainingSession;
using UnityEngine;
using Views;

namespace Controllers
{
    public class SessionController : MonoBehaviour
    {
        [SerializeField] private SessionView sessionView;
        
        private ISessionCallbacks model;

        public void SetModel(ISessionCallbacks model)
        {
            this.model = model;

            model.OnTaskError += OnTrainingErrorAction;
            model.OnMoveToNextTask += OnMoveToNextTask;
            model.OnTrainingCompleted += OnTrainingFinished;
        }

        private void OnMoveToNextTask(int order, string description)
        {
            sessionView.SetDescription(order + ". " + description);
            Debug.Log($"Model_OnMoveToNextTask : Next #{order}. Task - {description}");
        }

        private void OnTrainingFinished(float startTime, int errors)
        {
            sessionView.SetActiveSessionEndScreen(true);
            sessionView.SetFullTime(((int)(Time.time - startTime)).ToString());
            sessionView.SetErrorsCount(errors.ToString());
            sessionView.SetActiveSessionScreen(false);
            Debug.Log($"Model_OnTrainingFinished : Time - {Time.time - startTime}. Errors - {errors}");
        }

        private void OnTrainingErrorAction()
        {
            sessionView.SetActiveErrorScreen(true);
            sessionView.SetActiveSessionScreen(false);
            Debug.Log($"Model_OnTrainingErrorAction");
        }

        public void ContinueSession()
        {
            model.ContinueSession();
        }

        public void RestartSession()
        {
            model.RestartSession(Time.time);
        }

        public void CloseSession()
        {
            model.CloseSession();
        }
    }
}
