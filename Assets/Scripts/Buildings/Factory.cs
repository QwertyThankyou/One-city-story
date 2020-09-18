using UnityEngine;

public class Factory : MonoBehaviour
{
    private GameController _gameController;
    private int _currentDay;
    private bool _isGarbage;

    public GameObject garbage;
    
    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _currentDay = _gameController.dayNumber;
        _isGarbage = false;
    }
    
    void Update()
    {
        if (_gameController.dayNumber != _currentDay && !_isGarbage)
        {
            _currentDay = _gameController.dayNumber;
            Instantiate(garbage,new Vector3(transform.position.x, transform.position.y + 0.03f, transform.position.z), Quaternion.identity);
            _isGarbage = true;
        }
    }
}
