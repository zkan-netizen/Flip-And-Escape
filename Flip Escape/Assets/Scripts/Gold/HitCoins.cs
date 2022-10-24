using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCoins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gold")
        {
            GameManager._gamemanager.ScorePoint();
            other.gameObject.SetActive(false);
        }
    }
}
