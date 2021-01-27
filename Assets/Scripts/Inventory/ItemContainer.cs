using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class ItemSlot
{
    public Item item;
    public int count;

    // Sets the item in the drag and drop controller
    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    // Sets up the item in the item slot
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    // Clears a slot
    public void Clear()
    {
        item = null;
        count = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Item Container")]

// The inventory is a new Menu asset

public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    // Adds item to the container

    public void Add(Item item, int count = 1)
    {
        // Determining if the item is stackable
        if (item.stackable)
        {   
            // Finding slot with the same item
            ItemSlot itemSlot = slots.Find(x => x.item == item);


            if (itemSlot != null)
            {
                itemSlot.count += count;  // Adding the count
            }
            else
            {
                // If the item doesn't exist yet it is added
                itemSlot = slots.Find(x => x.item == null);

                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;  // 1 item
                }
            }
        }
        else
        {
            ItemSlot itemSlot = slots.Find(x => x.item == null);

            if (itemSlot != null)
            {
                itemSlot.item = item;
                itemSlot.count = count;
            }
        }
    }


    public void RemoveItem(Item removedItem, int count)
    {
        // Removing stackable items
        if (removedItem.stackable)
        {
            // Finding the item which is going to be removed

            ItemSlot itemSlot = slots.Find(slot => slot.item == removedItem);

            if (itemSlot == null)
            {
                return;
            }

            itemSlot.count-=count;

            if (itemSlot.count <= 0)   // Clearing the slot if it's empty
            {
                itemSlot.Clear();
            }
        }
        // Removing single items
        else
        {
            while (count > 0)
            {
                count--;
                ItemSlot itemSlot = slots.Find(slot => slot.item == removedItem);
                if (itemSlot == null)
                {
                    break;
                }
                itemSlot.Clear();
            }
        }
    }

}
