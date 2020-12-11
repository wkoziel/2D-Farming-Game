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

    // Checking whether the item icon is active in hierarchy
    private void Update()
    {
        if (itemIcon.activeInHierarchy == true)
        {
            // Assign mouse position to the item icon
            iconTransform.position = Input.mousePosition;

            // Unclick Raycast Target = not clickable by mouse

            // Implementing dropping out of the inventory - NOT DONE YET
            // Detecting whether we click inside or outside the inventory panel

            if (Input.GetMouseButtonDown(0))
            {
                // This checks whether we're over any UI elements
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    // Debug.Log("We are clicking outside the panel");
                }
            }
            
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
            // Storing the item and the count from the inventory item slot
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
        // If there's sth chosen update the icon
        // put the item sprite from the object into the item icon

        if (itemSlot.item == null)
        {
            // Hides the icon if nothing is chosen
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
