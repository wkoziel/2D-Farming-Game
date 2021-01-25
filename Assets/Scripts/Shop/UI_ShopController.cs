﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UI_ShopController : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    [SerializeField] private MoneyController money;
    public Button btn;
    [SerializeField] GameObject toolbarPanel;
    [SerializeField] GameObject inventoryPanel;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
    }

    private void Start()
    {
        Dictionary<string, Sprite> plantsDictionary = CreateSeedsFromSprite();
        //CreateItemButton(plantsDictionary["Seed3"], "Seed3", 100, 0, "50 red seeds");
        //CreateItemButton(plantsDictionary["Seeds1"], "Seeds1", 100, 1, "50 yellow seeds");

        // to trzeba naprawic:
        CreateItemButton(plantsDictionary["Seeds_Corn"], "Seeds_Corn", 100, 0, "4 corn seeds");
        CreateItemButton(plantsDictionary["Seeds_Parsley"], "Seeds_Parsley", 60, 1, "3 parsley seeds");
        CreateItemButton(plantsDictionary["Seeds_Tomato"], "Seeds_Tomato", 85, 2, "4 tomato seeds");
        CreateItemButton(plantsDictionary["Seeds_Strawberry"], "Seeds_Strawberry", 145, 3, "7 strawberry seeds");
        CreateItemButton(plantsDictionary["Seeds_Potato"], "Seeds_Potato", 70, 4, "Potato tuber");


        gameObject.SetActive(false);
        Hide();
    }

    private Dictionary<string, Sprite> CreateSeedsFromSprite()
    {
        Dictionary<string, Sprite> plantsDictionary = new Dictionary<string, Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Plants");

        foreach (Sprite sprite in sprites)
        {
            plantsDictionary.Add(sprite.name, sprite);
        }

        return plantsDictionary;

    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex, string displayedName)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 60f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, 200 + (-shopItemHeight * positionIndex));
        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(displayedName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;

        Item newItem = ScriptableObject.CreateInstance<Item>();

        foreach (ItemSlot itemSlot in GameManager.instance.allItemsContainer.slots)
        {
            if (itemSlot.item.Name == itemName)
            {
                newItem = itemSlot.item;
            }
        }

        btn = shopItemTransform.GetComponent<Button>();
        btn.onClick.AddListener(delegate { TaskWithParameters(itemCost, newItem); });
    }

    void TaskWithParameters(long itemCost, Item item)
    {
        money.substractMoney(itemCost);
        //Debug.Log(itemCost);

        if (money.canBuyItems(itemCost))
        {
            // w tym miejscu trzeba bedzie zrobic if dla kazdego z rodzajow nasiona
            if (item.Name.Contains("Seeds_Corn"))
            {
                GameManager.instance.inventoryContainer.Add(item, 4);
            }
            else if (item.Name.Contains("Seeds_Tomato"))
            {
                GameManager.instance.inventoryContainer.Add(item, 4);
            }
            else if (item.Name.Contains("Seeds_Strawberry"))
            {
                GameManager.instance.inventoryContainer.Add(item, 7);
            }
            else if (item.Name.Contains("Seeds_Parsley"))
            {
                GameManager.instance.inventoryContainer.Add(item, 3);
            }
            else if (item.Name.Contains("Seeds_Potato"))
            {
                GameManager.instance.inventoryContainer.Add(item, 1);
            }
            else
            {
                GameManager.instance.inventoryContainer.Add(item);
            }
        }
        

        toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        toolbarPanel.SetActive(true);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        inventoryPanel.SetActive(false);
        toolbarPanel.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    //dodać obsługę kliknięcia i zakup przedmiotu
}
