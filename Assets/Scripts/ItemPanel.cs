using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    // Instead of creating two very similar functionalities for InventoryPanel and
    // ToolbarPanel there's one class: ItemPanel

    //[SerializeField] ItemContainer inventory;
    public ItemContainer inventory;
    public List<InventoryButton> buttons;         // Serialized list of buttons

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
        // We need to add the exception for the toolbar panel where there are only 8 spots
        // to do that we add the buttons.Count condition

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
        // setting or hiding buttons based on the inventory

        // if there's no item in the slot then call the Clean method to hide what the button contains
        // when there's an item in a slot set it to the button

        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
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

    public virtual void OnClick(int id)
    {

    }
}
