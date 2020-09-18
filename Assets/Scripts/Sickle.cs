using UnityEngine;

public class Sickle : MonoBehaviour
{
    private Vector3 _defPos;
    private Quaternion _defRot;
    void Start()
    {
        _defPos = gameObject.transform.localPosition;
        _defRot = gameObject.transform.localRotation;
    }

    public void ResetPos()
    {
        gameObject.transform.localPosition = _defPos;
        gameObject.transform.localRotation = _defRot;
    }
}
