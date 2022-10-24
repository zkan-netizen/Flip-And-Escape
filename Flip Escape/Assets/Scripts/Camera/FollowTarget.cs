using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target;

    public float SmoothSpeed=0.125f;

    public Vector3 Offset;

    private void FixedUpdate()
    {
        
        Vector3 DesiredPose = Target.position + Offset;
        Vector3 SmoothedPosition =
            Vector3.Lerp(transform.position, DesiredPose, SmoothSpeed);
        transform.position = SmoothedPosition;
        
    }
}
