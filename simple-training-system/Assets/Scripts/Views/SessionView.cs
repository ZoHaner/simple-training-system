using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class SessionView : MonoBehaviour
    {
        [Header("Text fields")]
        [SerializeField] private Text DescriptionText;
        [SerializeField] private Text FullTimeText;
        [SerializeField] private Text ErrorsCountText;

        [Header("Screens")]
        [SerializeField] private GameObject ErrorScreen;
        [SerializeField] private GameObject SessionScreen;
        [SerializeField] private GameObject SessionEndScreen;

        public void SetDescription(string description)
        {
            DescriptionText.text = description;
        }

        public void SetFullTime(string time)
        {
            FullTimeText.text = time + " s.";
        }
        public void SetErrorsCount(string errorsCount)
        {
            ErrorsCountText.text = errorsCount;
        }
        public void SetActiveErrorScreen(bool active)
        {
            ErrorScreen.SetActive(active);
        }

        public void SetActiveSessionScreen(bool active)
        {
            SessionScreen.SetActive(active);
        }

        public void SetActiveSessionEndScreen(bool active)
        {
            SessionEndScreen.SetActive(active);
        }
    }
}
