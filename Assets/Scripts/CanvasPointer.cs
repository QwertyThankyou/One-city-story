using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPointer : MonoBehaviour
{
    private Canvas _canvas;
    void Start()
    {
        _canvas = gameObject.GetComponent<Canvas>();
        _canvas.worldCamera = GameObject.FindWithTag("Pointer").GetComponent<Camera>();
    }
    
    void Update()
    {
        
    }
}
