using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public NinjaData[] NinjaForSale;

    public int currentNinjaIndex;

    public GameObject[] NinjaModels;

    public Button BuyButton;

    public void Start()
    {
        foreach (NinjaData ninjas in NinjaForSale)
        {
            if (ninjas.price == 0)
            {
                ninjas.isUnlocked = true;
            }
            else
            {
                ninjas.isUnlocked =
                    PlayerPrefs.GetInt(ninjas.name, 0) == 0 ? false : true;
            }
        }

        currentNinjaIndex = PlayerPrefs.GetInt("SelectedNinja", 0);
        foreach (GameObject Ninjas in NinjaModels)
        {
            Ninjas.SetActive(false);
            NinjaModels[currentNinjaIndex].SetActive(true);
        }
    }

    public void ChangeNext()
    {
        NinjaModels[currentNinjaIndex].SetActive(false);
        currentNinjaIndex++;
        if (currentNinjaIndex == NinjaModels.Length)
        {
            currentNinjaIndex = 0;
        }
        NinjaModels[currentNinjaIndex].SetActive(true);
        NinjaData n = NinjaForSale[currentNinjaIndex];
        if (!n.isUnlocked) return;
        PlayerPrefs.SetInt("SelectedNinja", currentNinjaIndex);
    }

    public void UnlockNinja()
    {
        NinjaData n = NinjaForSale[currentNinjaIndex];
        PlayerPrefs.SetInt(n.name, 1);
        PlayerPrefs.SetInt("SelectedCar", currentNinjaIndex);
        n.isUnlocked = true;
        PlayerPrefs.SetInt("_score", GameManager._gamemanager.Score - n.price);
    }

    public void UpdateUI()
    {
        NinjaData n = NinjaForSale[currentNinjaIndex];
        if (n.isUnlocked)
        {
            BuyButton.gameObject.SetActive(false);
        }
        else
        {
            BuyButton.gameObject.SetActive(true);
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text =
                "Buy-" + n.price;
            if (n.price < GameManager._gamemanager.Score)
            {
                BuyButton.interactable = true;
            }
            else
            {
                BuyButton.interactable = false;
            }
        }
    }

    private void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("deleted");
        }
    }
}
