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

    public ItemContainer inventoryContainer;
    public ItemContainer allItemsContainer;
    public DragAndDropController dragAndDropController;
}
