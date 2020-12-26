using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActivator : MonoBehaviour
{
    // private GameObject _pointer;
    //
    // void Start()
    // {
    //     _pointer = GameObject.FindGameObjectWithTag("Pointer");
    // }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInChildren<Pointer>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponentInChildren<Pointer>().enabled = false;
    }
}
