using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] TileBase mowed;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, TileData> crops = new Dictionary<Vector2Int, TileData>();

    private void Start()
    {
        crops = ToolsCharacterController.crops;
    }

    public void Mow(Vector3Int position)
    {
        targetTilemap.SetTile(position, mowed);
    }

    public void Plow(Vector3Int position)
    {
        targetTilemap.SetTile(position, plowed);
    }

    public void Seed(Vector3Int position)
    {
        targetTilemap.SetTile(position, seeded);
    }

}
