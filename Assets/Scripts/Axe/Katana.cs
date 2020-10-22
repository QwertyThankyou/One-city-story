using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;
    void Start()
    {
        _defaultPosition = transform.position;
        _defaultRotation = transform.rotation;
    }

    public void ResetPosition()
    {
        transform.position = _defaultPosition;
        transform.rotation = _defaultRotation;
    }
}
