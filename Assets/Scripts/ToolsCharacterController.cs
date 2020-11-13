using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerControl character;
    Rigidbody2D rgbd2d;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 2f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTiles;
    [SerializeField] TileData toMowTiles;
    [SerializeField] TileData toSeedTiles;

    Vector3Int selectedTilePosition;
    bool selectable;

    public static Dictionary<Vector2Int, TileData> crops;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<PlayerControl>();
        rgbd2d = GetComponent<Rigidbody2D>();
        crops = new Dictionary<Vector2Int, TileData>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
        TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
        if (!crops.ContainsKey((Vector2Int)selectedTilePosition))
        {
            crops.Add((Vector2Int)selectedTilePosition, tileMapReadController.GetTileData(tileBase));
        }
        else
        {
            crops[(Vector2Int)selectedTilePosition] = tileMapReadController.GetTileData(tileBase);
        }
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    private void UseTool()
    {
        if (selectable == true)
        {
            TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = tileMapReadController.GetTileData(tileBase);

            if (tileData != plowableTiles && tileData != toMowTiles && tileData != toSeedTiles)
            {
                return;
            }

            if (crops[(Vector2Int)selectedTilePosition].ableToMow)
            {
                cropsManager.Mow(selectedTilePosition);
            }
            else if (crops[(Vector2Int)selectedTilePosition].plowable)
            {
                cropsManager.Plow(selectedTilePosition);
            }
            else if (crops[(Vector2Int)selectedTilePosition].ableToSeed)
            {
                cropsManager.Seed(selectedTilePosition);
            }
        }
    }
}
