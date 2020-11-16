using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;

    // serialized list of buttons
    [SerializeField] List<InventoryButton> buttons;

    private void Start()
    {
        SetIndex();    // cicles through inventory and sets indexes to the buttons
        Show();
    }

    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show()
    {
        // setting or hiding buttons based on the inventory

        // if there's no item in the slot then call the Clean method to hide what the button contains
        // when there's an item in a slot set it to the button

        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }
}
