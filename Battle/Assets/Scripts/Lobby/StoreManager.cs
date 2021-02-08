using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameObject dnaShortage;
    public GameObject purchaseComplate;
    public GameObject buyPopup;
    public List<GameObject> purchasedMark;
    public List<GameObject> productBtn;

    public int[] isPurchased = new int[10] {0,0,0,0,0,0,0,0,0,0};

    int selectProduct;
    int price;

    void Awake()
    {
        
        for(int i =0; i < 10; i++)
        {
            if (i == 0)
                isPurchased[i] = PlayerPrefs.GetInt("Product1");
            else if (i == 1)
                isPurchased[i] = PlayerPrefs.GetInt("Product2");
            else if (i == 2)
                isPurchased[i] = PlayerPrefs.GetInt("Product3");
            else if (i == 3)
                isPurchased[i] = PlayerPrefs.GetInt("Product4");
            else if (i == 4)
                isPurchased[i] = PlayerPrefs.GetInt("Product5");
            else if (i == 5)
                isPurchased[i] = PlayerPrefs.GetInt("Product6");
            else if (i == 6)
                isPurchased[i] = PlayerPrefs.GetInt("Product7");
            else if (i == 7)
                isPurchased[i] = PlayerPrefs.GetInt("Product8");
            else if (i == 8)
                isPurchased[i] = PlayerPrefs.GetInt("Product9");
            else if (i == 9)
                isPurchased[i] = PlayerPrefs.GetInt("Product10");
        }
    }

    void Start()
    {
        PlayerPrefs.SetInt("Product1", isPurchased[0]);
        PlayerPrefs.SetInt("Product2", isPurchased[1]);
        PlayerPrefs.SetInt("Product3", isPurchased[2]);
        PlayerPrefs.SetInt("Product4", isPurchased[3]);
        PlayerPrefs.SetInt("Product5", isPurchased[4]);
        PlayerPrefs.SetInt("Product6", isPurchased[5]);
        PlayerPrefs.SetInt("Product7", isPurchased[6]);
        PlayerPrefs.SetInt("Product8", isPurchased[7]);
        PlayerPrefs.SetInt("Product9", isPurchased[8]);
        PlayerPrefs.SetInt("Product10", isPurchased[9]);
    }

    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if(isPurchased[i]== 1)
            {
                purchasedMark[i].SetActive(true);
                productBtn[i].GetComponent<Button>().enabled = false;
            }
            else
            {
                purchasedMark[i].SetActive(false);
                productBtn[i].GetComponent<Button>().enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.DeleteKey("Product1");
            PlayerPrefs.DeleteKey("Product2");
            PlayerPrefs.DeleteKey("Product3");
            PlayerPrefs.DeleteKey("Product4");
            PlayerPrefs.DeleteKey("Product5");
            PlayerPrefs.DeleteKey("Product6");
            PlayerPrefs.DeleteKey("Product7");
            PlayerPrefs.DeleteKey("Product8");
            PlayerPrefs.DeleteKey("Product9");
            PlayerPrefs.DeleteKey("Product10");
            for (int i = 0; i < 10; i++)
            {
                isPurchased[i] = 0;
            }
        }
    }


    public void PurchaseBtn()
    {
        if(playerInfo.currentDNA < price)
        {
            dnaShortage.SetActive(true);
        }
        else
        {
            purchaseComplate.SetActive(true);
            
            playerInfo.currentDNA -= price;
            isPurchased[selectProduct - 1] = 1;

            if(selectProduct== 1)  PlayerPrefs.SetInt("Product1", isPurchased[0]);
            else if(selectProduct== 2)  PlayerPrefs.SetInt("Product2", isPurchased[1]);
            else if(selectProduct== 3)  PlayerPrefs.SetInt("Product3", isPurchased[2]);
            else if(selectProduct== 4)  PlayerPrefs.SetInt("Product4", isPurchased[3]);
            else if(selectProduct== 5)  PlayerPrefs.SetInt("Product5", isPurchased[4]);
            else if(selectProduct== 6)  PlayerPrefs.SetInt("Product6", isPurchased[5]);
            else if(selectProduct== 7)  PlayerPrefs.SetInt("Product7", isPurchased[6]);
            else if(selectProduct== 8)  PlayerPrefs.SetInt("Product8", isPurchased[7]);
            else if(selectProduct== 9)  PlayerPrefs.SetInt("Product9", isPurchased[8]);
            else if(selectProduct== 10)  PlayerPrefs.SetInt("Product10", isPurchased[9]);
        }
    }

    public void Product1()
    {
        selectProduct = 1;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product2()
    {
        selectProduct = 2;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product3()
    {
        selectProduct = 3;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product4()
    {
        selectProduct = 4;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product5()
    {
        selectProduct = 5;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product6()
    {
        selectProduct = 6;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product7()
    {
        selectProduct = 7;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product8()
    {
        selectProduct = 8;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product9()
    {
        selectProduct = 9;
        price = 100;
        buyPopup.SetActive(true);
    }
    public void Product10()
    {
        selectProduct = 10;
        price = 100;
        buyPopup.SetActive(true);
    }
}
