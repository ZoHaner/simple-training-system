using UnityEngine;

namespace Views
{
    /// <summary>
    /// View for device interaction
    /// </summary>
    public class DeviceView : MonoBehaviour
    {
        public void SetPosition(GameObject gameObject, Vector3 position)
        {
            gameObject.transform.position = position;
        }

        public void SetRotation(GameObject gameObject, Vector3 rotation)
        {
            gameObject.transform.rotation = Quaternion.Euler(rotation);
        }

        public void SetAnimationState(GameObject gameObject, string param, int paramValue)
        {
            var animator = gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetInteger(param, paramValue);
            }
        }
    }
}
