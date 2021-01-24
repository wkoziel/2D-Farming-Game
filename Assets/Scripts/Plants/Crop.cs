using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Globalization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/Crop")]

public class Crop : ScriptableObject
{
    public TileBase state0;

    public TileBase state1;

    public TileBase state2;

    public TileBase state3;

    public TileBase state4;

    public TileBase state5;

    //public Tilemap cropTilemap;

    public TileBase state;
    public Vector3Int position;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public string Name;

}