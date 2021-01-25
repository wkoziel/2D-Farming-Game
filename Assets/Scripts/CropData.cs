using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/CropData")]

public class CropData : ScriptableObject
{
    public List<TileBase> tiles;

    public bool noPlant;

    /*public bool withCorn;

    public bool withParsley;

    public bool withPotato;

    public bool withStrawberry;

    public bool withTomato;*/

    public bool planted;

    public bool collectible;

    public bool collectibleCorn;
    public bool collectibleParsley;
    public bool collectiblePotato;
    public bool collectibleStrawberry;
    public bool collectibleTomato;
}
