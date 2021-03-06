﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private ParticleSystem _particle;
    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;

    private void Start()
    {
        _particle = GetComponent<ParticleSystem>();
        _defaultPosition = transform.position;
        _defaultRotation = transform.rotation;
        _particle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            _particle.Play();
        }
    }

    public void ResetPosition()
    {
        transform.position = _defaultPosition;
        transform.rotation = _defaultRotation;
    }
}
