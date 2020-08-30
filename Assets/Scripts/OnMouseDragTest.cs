using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDragTest : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Debug.Log("drag");
    }

    private void OnMouseDown()
    {
        Debug.Log("down");
    }

    private void OnMouseUp()
    {
        Debug.Log("up");
    }
}
