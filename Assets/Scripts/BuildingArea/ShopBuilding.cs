using UnityEngine;

public class ShopBuilding : MonoBehaviour
{
    public HandShop handShop;
    
    private Vector3 _defPos;
    private Quaternion _defRot;
    void Start()
    {
        _defPos = gameObject.transform.localPosition;
        _defRot = gameObject.transform.localRotation;
    }

    public void ResetPos()
    {
        //handShop.isNeed = true;
        gameObject.transform.localPosition = _defPos;
        gameObject.transform.localRotation = _defRot;
        handShop.isNeed = false;
    }

    public void Take()
    {
        handShop.isNeed = true;
    }
}
