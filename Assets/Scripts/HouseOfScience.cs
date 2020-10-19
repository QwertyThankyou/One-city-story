using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseOfScience : MonoBehaviour
{
    public int houseCost = 100;
    public int huntingCost = 100;

    private GameController _gameController;

    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void HouseOpen()
    {
        if (_gameController.money >= houseCost)
        {
            _gameController.PeopleHouseOpen();
            _gameController.money -= houseCost;
        }
    }

    public void HuntingOpen()
    {
        if (_gameController.money >= huntingCost)
        {
            _gameController.HuntingHouseOpen();
            _gameController.money -= huntingCost;
        }
    }
}
