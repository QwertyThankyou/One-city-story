using UnityEngine;

public class HandShop : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject handShop;
    void Update()
    {
        if (leftHand.transform.localEulerAngles.z > 60 && leftHand.transform.localEulerAngles.z < 120)
        {
            handShop.SetActive(true);
        }
        else
        {
            handShop.SetActive(false);
        }
    }
}
