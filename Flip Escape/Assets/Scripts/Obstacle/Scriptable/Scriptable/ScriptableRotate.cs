using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rotate/RotateSettings")]
public class ScriptableRotate : ScriptableObject
{
    [SerializeField]
    private Vector3 Direction;

    public Vector3 _direction
    {
        get
        {
            return Direction;
        }
    }

    [SerializeField]
    private int RotSpeed;

    public int _rotspeed
    {
        get
        {
            return RotSpeed;
        }
    }
}
