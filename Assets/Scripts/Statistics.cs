using UnityEngine;

public class Statistics : MonoBehaviour
{
    private GameController _gameController;

    public TextMesh textMesh;
    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        textMesh = gameObject.GetComponent<TextMesh>();
    }
    
    void Update()
    {
        textMesh.text = "Престиж: " + _gameController.prestige + "; Экология: " + _gameController.ecology +
                        ";\nМакс. численность: " + _gameController.maxPopulation + "; Жители: " + _gameController.population +
                        ";\nОжидают работы: " + _gameController.waitingPopulation + "; Работают: " + _gameController.workingPopulation +
                        ";\nДоступно энергии: " + _gameController.availableEnergy + "; Потребляется: " + _gameController.neededEnergy +
                        ";\nБюджет: " + _gameController.money;
    }
}
