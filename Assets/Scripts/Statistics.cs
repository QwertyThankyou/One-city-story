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
        textMesh.text = "Экология: " + _gameController.ecology +
                        ";\nМакс. численность: " + _gameController.maxPopulation + "; Жители: " + _gameController.population +
                        ";\nБюджет: " + _gameController.money;
    }
}
