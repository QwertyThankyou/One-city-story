using UnityEngine;

public class HandShop : MonoBehaviour
{
    public GameObject handShop;
    [HideInInspector]public bool isNeed = false;
    
    void Update()
    {
        if ((gameObject.transform.localEulerAngles.z > 60 && gameObject.transform.localEulerAngles.z < 120) || isNeed)
        {
            handShop.SetActive(true);
        }
        else
        {
            handShop.SetActive(false);
        }
    }
}
