﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    private GameController _gameController;
    private ParticleSystem _particle;

    public GameObject vegetable;
    public List<Transform> _vegetableTrans;


    private float _time;
    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _particle = this.transform.Find("Particles").GetComponent<ParticleSystem>();

        _particle.Stop();
        _time = 0.0f;
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 60.0f)
        {
            _particle.Play();
            foreach (var trans in _vegetableTrans)
            {
                Instantiate(vegetable, trans.position, Quaternion.identity);
            }
            _time = 0.0f;
        }
    }

    //private void Collect()
    //{
    //    _time = 0.0f;
    //    _particle.Stop();
    //    _gameController.money += 100;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Sickle") && _particle.isPlaying)
    //    {
    //        Collect();
    //    }
    //}
}