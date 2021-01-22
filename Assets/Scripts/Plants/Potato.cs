using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Potato : MonoBehaviour
{
    [SerializeField] TileBase state0;

    [SerializeField] TileBase state1;

    [SerializeField] TileBase state2;

    [SerializeField] TileBase state3;

    [SerializeField] TileBase state4;

    [SerializeField] TileBase state5;

    [SerializeField] Tilemap cropTilemap;


    private string currentTime;

    public void Seed(Vector3Int position)
    {
        currentTime = Time.time.ToString("f6");
        Debug.Log(currentTime.ToString());
        cropTilemap.SetTile(position, state0);
    }
}
