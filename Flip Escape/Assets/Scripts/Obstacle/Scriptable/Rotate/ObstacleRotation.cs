using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField]
   private ScriptableRotate Rot;

    private void Update()
    {
        transform.Rotate(Rot._direction, Rot._rotspeed* Time.deltaTime);
    }
}
