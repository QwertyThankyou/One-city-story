using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool status;

    public GameObject gObject;

    private GameController _gameController;

    void Start()
    {
        status = false;
        gObject = null;
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _gameController.cells.Add(this);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShopBuilding"))
        {
            _gameController.selectedCell = this;
            _gameController.shadow.transform.position = this.gameObject.transform.position + new Vector3(0.0f, 0.03f, 0.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShopBuilding") && _gameController.selectedCell == this)
        {
            _gameController.selectedCell = null;
            _gameController.shadow.transform.position = _gameController.shadowDefPos;
        }
    }
}
