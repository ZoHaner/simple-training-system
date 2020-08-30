using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Вид для работы с устройством
/// </summary>
public class DeviceView : MonoBehaviour
{
    //private controller

    private Vector2 mousePosition;

    private void Start()
    {
        mousePosition = Input.mousePosition;
    }

    private void LateUpdate()
    {
        mousePosition = Input.mousePosition;
    }

    #region Setters
    public void SetPosition(GameObject gameObject, Vector3 position)
    {
        gameObject.transform.position = position;
    }

    public void SetRotation(GameObject gameObject, Vector3 rotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(rotation);
    }

    public void SetAnimationState(GameObject gameObject, int paramId, bool paramValue)
    {
        var animator = gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool(paramId, paramValue);
        }
    }
    #endregion

    #region Senders
    public void OnDrag(string name)
    {
        // controller -> name, , // Input.mousePoisition - mousePosition
    }

    public void OnEndDrag(string name)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick(string name)
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
