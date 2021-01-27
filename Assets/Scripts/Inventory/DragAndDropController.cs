using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;       // The item we currently drag around
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;              // Stores the position of the icon at the start
    Image itemIconImage;                      // Stores the item icon sprite

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }
    
    private void Update()
    {
        // Checking whether the item icon is active in hierarchy
        if (itemIcon.activeInHierarchy == true)
        {
            // Assign mouse position to the item icon
            iconTransform.position = Input.mousePosition;            
        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        // Puts the item from inventory to the drag and drop slot
        if (this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            // If the item slot is not empty we exchange items inside the item slots

            Item item = itemSlot.item;
            int count = itemSlot.count;

            // Assigns the currently dragged item into the inventory item slot
            itemSlot.Copy(this.itemSlot);

            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            // Hides the icon if no item is chosen
            itemIcon.SetActive(false);
        }
        else
        {
            // Assigns the new item icon
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
