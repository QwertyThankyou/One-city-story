using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private GameController _gameController;
    public int countHit = 3;
    public int money = 10;
    public int ecology = 1;

    private bool _isHit = false;

    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe") && _isHit == false)
        {
            _isHit = true;
            countHit--;
            if (countHit == 0)
            {
                _gameController.money += money;
                _gameController.ecology -= 1;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Axe")) _isHit = false;
    }
}
