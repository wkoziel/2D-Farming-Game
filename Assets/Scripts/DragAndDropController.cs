using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;          // The item we currently drag around

    private void Start()
    {
        itemSlot = new ItemSlot();
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
            ItemInInventory item = itemSlot.item;
            int count = itemSlot.count;

            // Assigns the currently dragged item into the inventory item slot
            itemSlot.Copy(this.itemSlot);

            this.itemSlot.Set(item, count);
        }
    }
}
