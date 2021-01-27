﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

// IPointerClickHandler starts to work every time we click on an UI object
public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] Image highlight;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;

        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            // Adjusting the count of the objects in inventory
            text.text = slot.count.ToString();
        }
        else
        {
            // When item isn't countable - hide the text
            text.gameObject.SetActive(false);
        }
    }

    // Removes sprite and hides icon and text
    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(myIndex);
    }

    public void Highlight(bool param)
    {
        highlight.gameObject.SetActive(param);
    }
}
