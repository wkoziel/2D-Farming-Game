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
    ToolbarController toolbarController;

    CountUpdateScript countUpdateScript;

    Vector3Int selectedTilePosition;
    bool selectable;

    public static Dictionary<Vector2Int, TileData> crops;

    public ItemContainer inventory;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<PlayerControl>();
        rgbd2d = GetComponent<Rigidbody2D>();
        crops = new Dictionary<Vector2Int, TileData>();
        toolbarController = GetComponent<ToolbarController>();
        //countUpdateScript = GetComponent<CountUpdateScript>();
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
        try
        {
            TileData tileData = tileMapReadController.GetTileData(tileBase);
            if (!(tileData is null))
            {
                if (!crops.ContainsKey((Vector2Int)selectedTilePosition))
                {
                    crops.Add((Vector2Int)selectedTilePosition, tileData);
                }
                else
                {
                    crops[(Vector2Int)selectedTilePosition] = tileData;
                }
            }
        }
        catch
        {
            return;
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
        if (selectable == true && toolbarController.GetItem != null)
        {
            TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = tileMapReadController.GetTileData(tileBase);

            if (tileData != plowableTiles && tileData != toMowTiles && tileData != toSeedTiles)
            {
                return;
            }

            // Debug.Log("Wybrane narzędzie: " + toolbarController.GetItem.Name);

            if (crops[(Vector2Int)selectedTilePosition].ableToMow && toolbarController.GetItem.Name == "Shovel" )
            {
                cropsManager.Mow(selectedTilePosition);
            }
            else if (crops[(Vector2Int)selectedTilePosition].plowable && toolbarController.GetItem.Name == "Hoe")
            {
                cropsManager.Plow(selectedTilePosition);
            }
            else if (crops[(Vector2Int)selectedTilePosition].ableToSeed && toolbarController.GetItem.isSeed == true)
            {
                cropsManager.Seed(selectedTilePosition);
                //toolbarController.ReduceCount();
                GameManager.instance.inventoryContainer.RemoveItem(toolbarController.GetItem, 5);

                //countUpdateScript.countValue -= 5;

            }
        }
    }
}
