using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitReaction : PlayerHit
{
    GameObject toolbar;
    ToolbarController toolbarController;
    public override void Hit()
    {
        toolbar = GameObject.FindWithTag("toolbar");
        toolbarController = GetComponent<ToolbarController>();
        
        switch (toolbarController.GetItem.Name)
        {
            case "Food_Corn":
                Debug.Log("Zjadłeś kukurydze");
                AddHunger(20);
                break;

            case "Food_Parsley":
                Debug.Log("Zjadłeś pietruszkę");
                AddHealth(5);
                AddHunger(10);
                break;

            case "Food_Potato":
                Debug.Log("Zjadłeś ziemniaka");
                AddHealth(5);
                AddHunger(40);
                break;

            case "Food_Strawberry":
                Debug.Log("Zjadłeś truskawkę");
                AddHealth(30);
                AddHunger(10);
                break;

            case "Food_Tomato":
                Debug.Log("Zjadłeś pomidora");
                AddHunger(30);
                break;
        }
        GameManager.instance.inventoryContainer.RemoveItem(GameManager.instance.toolbarControllerGlobal.GetItem, 1);
        toolbar.SetActive(!toolbar.activeInHierarchy);
        toolbar.SetActive(true);
    }

    void AddHunger(int add)
    {
        if(HungerController.currentHunger + add < 100)
            HungerController.currentHunger += add;
        else
            HungerController.currentHunger = 100;
    }

    void AddHealth(int add)
    {
        if (HealthController.currentHealth + add < 100)
            HealthController.currentHealth += add;
        else
            HealthController.currentHealth = 100;
    }
}