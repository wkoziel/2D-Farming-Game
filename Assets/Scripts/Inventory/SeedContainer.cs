using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

// Class which helps to store all Crop objects
public class SeedSlot
{
    public Crop item;
    public int count;

    // Sets the item in the drag and drop controller
    public void Copy(SeedSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    // Sets up the item in the item slot
    public void Set(Crop item, int count)
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
[CreateAssetMenu(menuName = "Data/Seed Container")]

public class SeedContainer : ScriptableObject
{
    public List<SeedSlot> slots;

    // Defining all methods which we use to interact with the inventory

    // Adds item to the container
    public void Add(Crop item, int count = 1)
    {
        // Determining if the item is stackable - if it's not then find the first free
        // slot and insert the item there

            SeedSlot SeedSlot = slots.Find(x => x.item == null);

            // If there is no empty slots item will not be added
            if (SeedSlot != null)
            {
                SeedSlot.item = item;
                SeedSlot.count = count;
            }
        }
    

}
