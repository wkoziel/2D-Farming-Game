using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SeedSlot
{
    public Corn item;
    public int count;

    // Set the item in the drag and drop controller
    public void Copy(SeedSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }

    // Sets up the item in the item slot
    public void Set(Corn item, int count)
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
    public void Add(Corn item, int count = 1)
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
