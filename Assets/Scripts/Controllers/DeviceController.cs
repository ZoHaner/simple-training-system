using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataModel;

public class DeviceController : MonoBehaviour
{
    private IDeviceOperations model;

    // ToDo: Для тестов
    private void Start()
    {
        TrainingSessionData session = new TrainingSessionData(0);
        SetModel(session);
    }

    public void SetModel(IDeviceOperations model)
    {
        this.model = model;
        model.OnElementsParamsChanged += OnElementsParamsChanged;
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

    private void OnElementsParamsChanged()
    {
        // -> view 
    }
}
