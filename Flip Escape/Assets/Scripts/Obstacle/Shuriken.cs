using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (GameManager._gamemanager.isGameStart)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * 15);
        }
        if (this.gameObject.transform.position.z <0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
