﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<Building> shop = new List<Building>();
    public List<Cell> cells = new List<Cell>();

    public Cell selectedCell;
    public GameObject buildingObject;

    public bool buying;
    public int indexShop;

    public GameObject shadow;
    public Vector3 shadowDefPos;

    public GameObject peopleHouse;
    public GameObject huntingHouse;

    public GameObject loseUI;
    public GameObject winUI;

    [Header("Music")]
    public AudioManager audioManager;
    public AudioClip startMusic;
    public AudioClip reNovation;
    public AudioClip nightWalk;
    public AudioClip nightRain;

    [Header("Pointer")] 
    public GameObject pointer;
    public GameObject inputModule;
    

    //
    //variables
    //
    [Header("Variables")]
    public int ecology;

    public int maxPopulation;
    public int population;

    public int money;
    private int _lastMoney;

    public float gameSeconds;
    public float gameMinutes;
    public int dayNumber = 1;

    private string _stringSeconds;
    private string _stringMinutes;
    private string _stringDayNumber;

    public TextMesh textTime;

    public int speedMultiplier = 1;

    private bool _timeStop;

    private bool _isContinue = false;

    void Start()
    {
        selectedCell = null;
        buildingObject = null;
        buying = false;
        indexShop = -1;
        ecology = 10;
        _timeStop = false;
        shadowDefPos = shadow.transform.position;
        StartCoroutine(CTime());

        peopleHouse.SetActive(false);
        huntingHouse.SetActive(false);   // Кто будет делать, это заменить при создании сохранения
        
        loseUI.SetActive(false);
        winUI.SetActive(false);
        
        audioManager.Play("ForestBackground");
        audioManager.Play("BirdSinging");
        audioManager.Play("StartMusic");
        StartCoroutine(Music());
        
        _lastMoney = money;
    }


    private IEnumerator Music()
    {
        yield return new WaitForSeconds(startMusic.length + 300f);
        audioManager.Play("reNovation");
        yield return new WaitForSeconds(reNovation.length + 300f);
        audioManager.Play("NightWalk");
        yield return new WaitForSeconds(nightWalk.length + 300f);
        audioManager.Play("NightRain");
        StopCoroutine(Music());
    }


    private IEnumerator CTime()
    {
        while (!_timeStop)
        {
            yield return null;

            gameSeconds = gameSeconds + Time.deltaTime * 30 * speedMultiplier;

            if (gameSeconds >= 60.0f)
            {
                gameMinutes = gameMinutes + 1.0f;
                gameSeconds = 0.0f;
            }

            if (gameMinutes >= 24.0f)
            {
                gameMinutes = 0.0f;
                dayNumber++;
                ecology += 10;
            }

            _stringDayNumber = dayNumber.ToString();
            _stringSeconds = ((int)gameSeconds).ToString();
            _stringMinutes = ((int)gameMinutes).ToString();

           // textTime.text = "День " + _stringDayNumber + "\n" + _stringMinutes + ":00 AM";
        }
    }

    private void Update()
    {
        if (money <= 0 || ecology <= 0)
        {
            loseUI.SetActive(true);
            ActiveInput();
        }

        if (money >= 1000 && !_isContinue)
        {
            winUI.SetActive(true);
            ActiveInput();
        }

        if (_lastMoney < money)
        {
            audioManager.Play("Coin");
            _lastMoney = money;
        }

        if (_lastMoney > money) _lastMoney = money;
    }


    public void StartBuild(int index)
    {
        if (money >= shop[index].cost)
        {
            indexShop = index;
            foreach (Cell tmp in cells)
            {
                if (!tmp.status)
                {
                    tmp.gameObject.SetActive(true);
                }
            }
            buying = true;
        }
        else
        {
            
        }
    }

    public void EndBuild()
    {
        if (selectedCell != null && selectedCell.status == false)
        {
            money -= shop[indexShop].cost;
            selectedCell.gObject = Instantiate(shop[indexShop].gObject, selectedCell.transform.position + new Vector3(0.0f, 0.03f, 0.0f), Quaternion.identity);
            selectedCell.status = true;
            selectedCell = null;
            shadow.transform.position = shadowDefPos;
            audioManager.Play("Buildings");
        }
        foreach (Cell tmp in cells)
        {
            tmp.gameObject.SetActive(false);
        }
        indexShop = -1;
        buying = false;
    }

    public void PeopleHouseOpen()
    {
        peopleHouse.SetActive(true);
        audioManager.Play("Upgrade");
    }

    public void HuntingHouseOpen()
    {
        huntingHouse.SetActive(true);
        audioManager.Play("Upgrade");
    }

    private void ActiveInput()
    {
        pointer.SetActive(true);
        inputModule.SetActive(true);   // необязятельно при нахождении инпута в поинтере
    }
    
    // UI поражения и победы и звук
    public void Restart()
    {
        Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene("Main Menu");
    }

    public void ContinueGame()
    {
        winUI.SetActive(false);
        pointer.SetActive(false);
        _isContinue = true;
    }
}
