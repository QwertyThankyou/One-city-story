using UnityEngine;

public class HandShop : MonoBehaviour
{
    public GameObject handShop;
    void Update()
    {
        if (gameObject.transform.localEulerAngles.z > 60 && gameObject.transform.localEulerAngles.z < 120)
        {
            handShop.SetActive(true);
        }
        else
        {
            handShop.SetActive(false);
        }
    }
}
