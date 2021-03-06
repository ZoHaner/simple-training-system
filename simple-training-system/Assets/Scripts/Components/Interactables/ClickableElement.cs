using Controllers;
using DataModel.Elements.Properties;
using UnityEngine;

namespace Components.Interactables
{
    public class ClickableElement : InteractableElement
    {
        [SerializeField] private ButtonState initialState;

        private DeviceController deviceController;

        private void Awake()
        {
            var controller = FindObjectOfType<DeviceController>();
            if (controller != null)
            {
                deviceController = controller;
            }
            else
            {
                Debug.LogError("RotatableElement : DeviceController wasn't found");
            }

            // Initial animation settings
            var animator = GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetInteger("state", (int)initialState);
            }
        }

        public ButtonState GetButtonState()
        {
            return initialState;
        }

        private void OnMouseUp()
        {
            deviceController.OnClick(gameObject.name);
        }
    }
}