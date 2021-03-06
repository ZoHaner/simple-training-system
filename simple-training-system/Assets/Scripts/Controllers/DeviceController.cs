using System;
using System.Collections.Generic;
using Components.Interactables;
using DataModel.Elements;
using DataModel.Elements.Properties;
using DataModel.TrainingSession;
using UnityEngine;
using Views;

namespace Controllers
{
    public class DeviceController : MonoBehaviour
    {
        [SerializeField] private DeviceView view;

        private Dictionary<string, GameObject> sceneElements = new Dictionary<string, GameObject>();
        private IDeviceOperations model;

        public void SetModel(IDeviceOperations model)
        {
            this.model = model;
            model.OnElementsParamsChanged += OnElementsParamsChanged;
        }

        public void LoadNewDevice(InteractableElement[] interactableElements)
        {
            sceneElements.Clear();

            foreach (var element in interactableElements)
            {
                sceneElements.Add(element.name, element.gameObject);
            }

            model.LoadNewDevice(interactableElements, Time.time);
        }

        private void OnElementsParamsChanged(KeyValuePair<string, DeviceElement> element)
        {
            DeviceElement deviceElement = element.Value;
            string elementName = element.Key;
            foreach (var prop in deviceElement.Properties)
            {
                switch (prop)
                {
                    case ButtonProperty bp:
                        view.SetAnimationState(sceneElements[elementName], "state", (int)bp.ButtonState);
                        break;
                    case PositionProperty pp:
                        view.SetPosition(sceneElements[elementName], pp.Position);
                        break;
                    case RotationProperty rp:
                        view.SetRotation(sceneElements[elementName], rp.Rotation);
                        break;
                    default:
                        throw new NotImplementedException($"DeviceController : Property {prop.GetType()} wasn't found!");
                }
            }
        }

        public void OnClick(string name)
        {
            model.Click(name);
        }

        public void OnDrag(string name)
        {
            model.Drag(name, Input.mousePosition);
        }

        public void OnEndDrag(string name)
        {
            model.EndDrag(name, Input.mousePosition);
        }
    }
}
