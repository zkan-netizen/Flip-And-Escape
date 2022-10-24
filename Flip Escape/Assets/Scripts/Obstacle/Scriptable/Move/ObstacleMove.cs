using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{   [SerializeField]
    private ScriptableMove Move;

    void Update()
    {
        transform.position =
            Vector3
                .Lerp(Move._pose1,
                Move._pose2,
                (Mathf.Sin(Move._sidespeed * Time.time) + 1.0f) / 2.0f);
    }
}
