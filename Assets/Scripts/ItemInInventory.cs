using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ItemInInventory")]

public class ItemInInventory : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
}
