using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsReadController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] List<CropData> cropDatas;
    Dictionary<TileBase, CropData> cropsFromTiles;

    private void Start()
    {
        cropsFromTiles = new Dictionary<TileBase, CropData>();

        foreach (CropData cropData in cropDatas)
        {
            foreach (TileBase tile in cropData.tiles)
            {
                cropsFromTiles.Add(tile, cropData);
            }
        }
    }

    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        Vector3 worldPosition;


        if (mousePosition)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            worldPosition = position;
        }


        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);

        return gridPosition;
    }


    public TileBase GetTileBase(Vector3Int gridPosition)
    {
        TileBase tile = tilemap.GetTile(gridPosition);

        return tile;
    }

    public CropData GetCropData(TileBase tilebase)
    {
        return cropsFromTiles[tilebase];
    }
}


