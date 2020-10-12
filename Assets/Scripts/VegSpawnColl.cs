using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegSpawnColl : MonoBehaviour
{
    [HideInInspector]
    public bool isHave = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vegetable")) isHave = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vegetable")) isHave = false;
    }
}
