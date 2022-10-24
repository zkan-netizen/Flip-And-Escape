using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Move/MoveSettings")]
public class ScriptableMove : ScriptableObject
{
    [SerializeField]
    private Vector3 Pose1;

    public Vector3 _pose1
    {
        get
        {
            return Pose1;
        }
    }

    [SerializeField]
    private Vector3 Pose2;

    public Vector3 _pose2
    {
        get
        {
            return Pose2;
        }
    }

    [SerializeField]
    private float SideSpeed;

    public float _sidespeed
    {
        get
        {
            return SideSpeed;
        }
    }

    //giotine
    // private Vector3 pos1 = new Vector3(3.25f,0.5f,35);
    //  private Vector3 pos2 = new Vector3(-3.25f,0.5f,35);
    //  public float speed = 1.0f;

    //  void Update() {
    //      transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    //  }
}
