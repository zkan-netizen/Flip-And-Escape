using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsHolder : MonoBehaviour
{
    public int currentNinjaIndex;

    public GameObject CamTarget;

 

    public GameObject SecondCamera;

    public GameObject[] NinjaModels;

    public void Start()
    {
        currentNinjaIndex = PlayerPrefs.GetInt("SelectedNinja", 0);
        foreach (GameObject Ninjas in NinjaModels)
        {
            Ninjas.SetActive(false);
            NinjaModels[currentNinjaIndex].SetActive(true);
            CamTarget.transform.parent =
                NinjaModels[currentNinjaIndex].transform;
            
            SecondCamera.transform.parent =
                NinjaModels[currentNinjaIndex].transform;
        }
    }
}
