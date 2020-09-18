using UnityEngine;

public class Garbage : MonoBehaviour
{
    private GameController _gameController;
    
    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    
    public void ThrowOut()
    {
        Destroy(this.gameObject);
    }
}
