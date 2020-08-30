using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataModel;

public class SessionController : MonoBehaviour
{
    ISessionOperations model;

    public void SetModel(ISessionOperations model)
    {
        this.model = model;
    }

    public void LoadNewDevice(InteractableElement[] interactableElements)
    {
        model.LoadNewDevice(interactableElements);
    }
}
