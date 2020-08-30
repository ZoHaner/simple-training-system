using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSearchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var res = FindObjectOfType<InteractableElement>();
        Debug.Log(res.name);
    }


}
