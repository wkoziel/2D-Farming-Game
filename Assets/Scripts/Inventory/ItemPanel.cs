using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic class for the inventory and toolbar panel
public class ItemPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<InventoryButton> buttons;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SetIndex();    // Cicles through inventory and sets indexes to the buttons
        Show();
    }

    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                // Hiding what the slot in inventory contains in the button
                buttons[i].Clean();
            }
            else
            {
                // Setting the button to the item in the inventory
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

    public virtual void OnClick(int id)
    {

    }
}
