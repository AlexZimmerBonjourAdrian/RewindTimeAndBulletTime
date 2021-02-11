using UnityEngine;

public class CPointInTime : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;

    public CPointInTime (Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
