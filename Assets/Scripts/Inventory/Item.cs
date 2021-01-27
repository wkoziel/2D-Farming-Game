using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]

// Represent the data of a single item
public class Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
    public bool isSeed;
}
