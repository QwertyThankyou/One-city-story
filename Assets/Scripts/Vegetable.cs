using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public GameObject particle;
    public int money = 10;

    private GameController _gameController;

    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vegetable"))
        {
            _gameController.money += money;
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
