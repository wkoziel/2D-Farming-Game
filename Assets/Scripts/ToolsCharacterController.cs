﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerControl character;
    Rigidbody2D rgbd2d;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] CropsReadController cropsReadController;
    [SerializeField] float maxDistance = 2f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTiles;
    [SerializeField] TileData toMowTiles;
    [SerializeField] TileData toSeedTiles;
    ToolbarController toolbarController;
    [SerializeField] GameObject toolbarPanel;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    /*[SerializeField] Corn corn;
    [SerializeField] Parsley parsley;
    [SerializeField] Potato potato;
    [SerializeField] Strawberry strawberry;
    [SerializeField] Tomato tomato;*/
    //[SerializeField] Crop crop;

    private static int cornAmount = 4;
    private static int parsleyAmount = 3;
    private static int potatoAmount = 1;
    private static int strawberryAmount = 6;
    private static int tomatoAmount = 3;


    Vector3Int selectedTilePosition;
    Vector3Int selectedCropPosition;
    bool selectable;

    public static Dictionary<Vector2Int, TileData> fields;
    public static Dictionary<Vector2Int, CropData> crops;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<PlayerControl>();
        rgbd2d = GetComponent<Rigidbody2D>();
        fields = new Dictionary<Vector2Int, TileData>();
        crops = new Dictionary<Vector2Int, CropData>();
        toolbarController = GetComponent<ToolbarController>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0)) // lewy przycisk myszki
        {
            
            if (UseToolWorld() == true )
            {
                return;
            }
            UseTool();
        }
    }

    private bool CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name.Contains("Tree"))
            {
                return true;
            }
            if (hit.collider.gameObject.name.Contains("CampFire"))
            {
                return true;
            }
           
        }
        return false;
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
                if (!fields.ContainsKey((Vector2Int)selectedTilePosition))
                {
                    fields.Add((Vector2Int)selectedTilePosition, tileData);
                }
                else
                {
                    fields[(Vector2Int)selectedTilePosition] = tileData;
                }
            }
        }
        catch
        {
            return;
        }

        selectedCropPosition = cropsReadController.GetGridPosition(Input.mousePosition, true);
        TileBase cropBase = cropsReadController.GetTileBase(selectedTilePosition);
        try
        {
            CropData cropData = cropsReadController.GetCropData(cropBase);
            if (!(cropData is null))
            {
                if (!crops.ContainsKey((Vector2Int)selectedTilePosition))
                {
                    crops.Add((Vector2Int)selectedTilePosition, cropData);
                }
                else
                {
                    crops[(Vector2Int)selectedTilePosition] = cropData;
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

    // interacting with physical objects in the world
    private bool UseToolWorld()
    {
        // CUTTING TREE
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);


        foreach (Collider2D collidor in colliders)
        {
            ToolHit hitTree = collidor.GetComponent<ToolHit>();
            CampFireHit hitFire = collidor.GetComponent<CampFireHit>();
            if (hitTree != null && toolbarController.GetItem.Name == "Axe" && CastRay() == true)
            {
                hitTree.Hit();
                // Debug.Log("we can hit");
                return true;
            }
            if (hitFire != null && toolbarController.GetItem.Name == "Wood" && CastRay() == true)
            {
                hitFire.Hit();
                return true;
            }
        }

        return false;
    }

    private void RefreshToolbar()
    {
        toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        toolbarPanel.SetActive(true);
    }

    private void UseTool()
    {
        // when sth is present on the grid but you can't plant there
        if (selectable == true && toolbarController.GetItem != null)
        {
            TileBase tileBase = tileMapReadController.GetTileBase(selectedTilePosition);
            TileData tileData = tileMapReadController.GetTileData(tileBase);
            //TileData cropData = cropsReadController.GetTileData(tileBase);

            if (tileData != plowableTiles && tileData != toMowTiles && tileData != toSeedTiles)
            {
                return;
            }

            // Debug.Log("Wybrane narzędzie: " + toolbarController.GetItem.Name);
            //Debug.Log(crops[(Vector2Int)selectedTilePosition]);
            //if ((!crops[(Vector2Int)selectedTilePosition].withTomato && !crops[(Vector2Int)selectedTilePosition].withStrawberry && !crops[(Vector2Int)selectedTilePosition].withPotato && !crops[(Vector2Int)selectedTilePosition].withParsley && !crops[(Vector2Int)selectedTilePosition].withCorn) || !crops[(Vector2Int)selectedTilePosition])
            if (crops[(Vector2Int)selectedTilePosition].noPlant)
            {
                if (fields[(Vector2Int)selectedTilePosition].ableToMow && toolbarController.GetItem.Name == "Shovel")
                {
                    cropsManager.Mow(selectedTilePosition);
                }
                else if (fields[(Vector2Int)selectedTilePosition].plowable && toolbarController.GetItem.Name == "Hoe")
                {
                    cropsManager.Plow(selectedTilePosition);
                }
                else if (fields[(Vector2Int)selectedTilePosition].ableToSeed && toolbarController.GetItem.isSeed == true)
                {
                    switch (toolbarController.GetItem.Name)
                    {
                        case "Seeds_Corn":
                            // Checking whether we have more than 4 seeds to seed
                            if (GameManager.instance.inventoryContainer.slots[toolbarController.selectedTool].count >= 4)
                            {
                                cropsManager.SeedCrop(selectedTilePosition, "corn");
                                GameManager.instance.inventoryContainer.RemoveItem(toolbarController.GetItem, cornAmount);   // Deletes 4 seeds
                            }
                        break;
                        case "Seeds_Parsley":
                            // Checking whether we have more than 3 seeds to seed
                            if (GameManager.instance.inventoryContainer.slots[toolbarController.selectedTool].count >= 3)
                            {
                                cropsManager.SeedCrop(selectedTilePosition, "parsley");
                                GameManager.instance.inventoryContainer.RemoveItem(toolbarController.GetItem, parsleyAmount);  // Deletes 3 seeds
                            }
                        break;
                        case "Seeds_Potato":
                            // Checking whether we have more than 1 seed to seed
                            if (GameManager.instance.inventoryContainer.slots[toolbarController.selectedTool].count >= 1)
                            {
                                cropsManager.SeedCrop(selectedTilePosition, "potato");
                                GameManager.instance.inventoryContainer.RemoveItem(toolbarController.GetItem, potatoAmount);   // Deletes 1 seed
                            }
                        break;
                        case "Seeds_Strawberry":
                            // Checking whether we have more than 6 seeds to seed
                            if (GameManager.instance.inventoryContainer.slots[toolbarController.selectedTool].count >= 6)
                            {
                                cropsManager.SeedCrop(selectedTilePosition, "strawberry");
                                GameManager.instance.inventoryContainer.RemoveItem(toolbarController.GetItem, strawberryAmount); // Deletes 6 seeds
                            }
                        break;
                        case "Seeds_Tomato":
                            // Checking whether we have more than 3 seeds to seed
                            if (GameManager.instance.inventoryContainer.slots[toolbarController.selectedTool].count >= 3)
                            {
                                cropsManager.SeedCrop(selectedTilePosition, "tomato");
                                GameManager.instance.inventoryContainer.RemoveItem(toolbarController.GetItem, tomatoAmount);   // Deletes 3 seeds
                            }
                        break;
                    }

                    // Refreshing the count of seeds
                    RefreshToolbar();

                }
                
            }
            
            else if (crops[(Vector2Int)selectedTilePosition].collectibleCorn)
            {
                cropsManager.Collect(selectedTilePosition, "corn");
                foreach (ItemSlot itemSlot in GameManager.instance.allItemsContainer.slots)
                {
                    if (itemSlot.item.Name == "Food_Corn")
                    {
                        GameManager.instance.inventoryContainer.Add(itemSlot.item, cornAmount);
                        RefreshToolbar();
                        break;
                    }
                }
                //Debug.Log("dodajemy corn");

            }
            else if (crops[(Vector2Int)selectedTilePosition].collectibleParsley)
            {
                cropsManager.Collect(selectedTilePosition, "parsley");
                foreach (ItemSlot itemSlot in GameManager.instance.allItemsContainer.slots)
                {
                    if (itemSlot.item.Name == "Food_Parsley")
                    {
                        GameManager.instance.inventoryContainer.Add(itemSlot.item, parsleyAmount);
                        RefreshToolbar();
                        break;
                    }
                }
                //Debug.Log("dodajemy parsley");
            }
            else if (crops[(Vector2Int)selectedTilePosition].collectiblePotato)
            {
                cropsManager.Collect(selectedTilePosition, "potato");
                foreach (ItemSlot itemSlot in GameManager.instance.allItemsContainer.slots)
                {
                    if (itemSlot.item.Name == "Food_Potato")
                    {
                        GameManager.instance.inventoryContainer.Add(itemSlot.item, potatoAmount);
                        RefreshToolbar();
                        break;
                    }
                }
                //Debug.Log("dodajemy potato");
            }
            else if (crops[(Vector2Int)selectedTilePosition].collectibleStrawberry)
            {
                cropsManager.Collect(selectedTilePosition, "strawberry");
                foreach (ItemSlot itemSlot in GameManager.instance.allItemsContainer.slots)
                {
                    if (itemSlot.item.Name == "Food_Strawberry")
                    {
                        GameManager.instance.inventoryContainer.Add(itemSlot.item, strawberryAmount);
                        RefreshToolbar();
                        break;
                    }
                }
                //Debug.Log("dodajemy strawberry");
            }
            else if (crops[(Vector2Int)selectedTilePosition].collectibleTomato)
            {
                cropsManager.Collect(selectedTilePosition, "tomato");
                foreach (ItemSlot itemSlot in GameManager.instance.allItemsContainer.slots)
                {
                    if (itemSlot.item.Name == "Food_Tomato")
                    {
                        GameManager.instance.inventoryContainer.Add(itemSlot.item, tomatoAmount);
                        RefreshToolbar();
                        break;
                    }
                }
                //Debug.Log("dodajemy tomato");
            }

        }
    }
}
