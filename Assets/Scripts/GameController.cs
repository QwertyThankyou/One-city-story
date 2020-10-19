using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //
    //variables
    //

    public int prestige;
    public int ecology;

    public int maxPopulation;
    public int population;
    public int waitingPopulation;
    public int workingPopulation;
    //public int arrivingPopulation;

    public int money;
    //public int income;

    public int availableEnergy;
    public int neededEnergy;
    
    
    
    
    
    public float gameSeconds;
    public float gameMinutes;
    public int dayNumber = 1;

    private string _stringSeconds;
    private string _stringMinutes;
    private string _stringDayNumber;

    public TextMesh textTime;

    public int speedMultiplier = 1;

    private bool _timeStop;

    void Start()
    {
        money = 100;
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
    }

    public void HuntingHouseOpen()
    {
        huntingHouse.SetActive(true);
    }
}
