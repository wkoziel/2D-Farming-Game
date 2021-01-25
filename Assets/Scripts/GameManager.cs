using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemContainer allItemsContainer;
    public SeedContainer allSeedsContainer;
    public DragAndDropController dragAndDropController;

    public ToolbarController toolbarControllerGlobal;
}
