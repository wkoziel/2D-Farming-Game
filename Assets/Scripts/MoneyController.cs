using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public static long money;
    public Text moneyText; 

    void Start()
    {
        money = 200;
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void addMoney(long moneyToAdd)
    {
        money += moneyToAdd;
    }

    public void substractMoney(long moneyToSubstract)
    {
        if(money - moneyToSubstract < 0)
        {
            Debug.Log("Cannot substract money !");
        }
        else
        {
            money -= moneyToSubstract;
        }
    }

    public bool canBuyItems(long moneyToSubstract)
    {
        if (money - moneyToSubstract < 0)
        {
            return false;
        }
        else return true;
    }

    //private string formatMoney(long moneyToFormat)
    //{
    //    string suffix;
    //    if (moneyToFormat < 1000)
    //    {
    //        moneyToFormat = moneyToFormat;
    //        suffix = "";
    //    }
    //    else if (moneyToFormat < 1000000)
    //    {
    //        moneyToFormat = moneyToFormat / 1000;
    //        suffix = "K";
    //    }
    //    else if (moneyToFormat < 1000000000)
    //    {
    //        moneyToFormat = moneyToFormat / 1000000;
    //        suffix = "M";
    //    }
    //    else
    //    {
    //        moneyToFormat = moneyToFormat / 1000000000;
    //        suffix = "B";
    //    }
    //    return moneyToFormat.ToString() + suffix;
    //}
}
