﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_ShopController : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        //gameObject.enabled = false ;
    }

    private void Start()
    {
        //CreateItemButton(Resources.Load<Sprite>("starter_hoe"), "Starter hoe", 30, 0);        //to jest ten sam obiekt, który jest domyślnie utworzony jako shopItemTemplate
        CreateItemButton(Resources.Load<Sprite>("starter_shovel"), "Starter shovel", 30, 1);
        CreateItemButton(Resources.Load<Sprite>("backpack"), "Backpack", 100, 2);
        gameObject.SetActive(false);
        Hide();
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    //dodać obsługę kliknięcia i zakup przedmiotu
}
