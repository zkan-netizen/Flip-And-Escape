using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyotine : MonoBehaviour
{  
    void Guillotine()
    {
       float angle = Mathf.Sin(Time.time) * 70;
        if (this.gameObject.transform.position.z>165)
        {
         
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (this.gameObject.transform.position.z<165)
        {
           
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
        }
    }

    void Update()
    {
        Guillotine();
    }
}
