using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase plowed;
    /*[SerializeField] TileBase seeded_corn;
    [SerializeField] TileBase seeded_parsley;
    [SerializeField] TileBase seeded_potato;
    [SerializeField] TileBase seeded_strawberry;
    [SerializeField] TileBase seeded_tomato;*/
    //[SerializeField] TileBase seeded;
    [SerializeField] TileBase mowed;
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] Tilemap cropTilemap;
    ToolbarController toolbarController;

    Dictionary<Vector2Int, TileData> crops = new Dictionary<Vector2Int, TileData>();

    TileBase seeded;
    public List<Corn> corns;
    public GameObject cornPrefab;
    Corn corn;

    private void Awake()
    {
        corn = ScriptableObject.CreateInstance<Corn>();

    }

    private void Start()
    {
        // Looking for the corn item in the game
        foreach (SeedSlot itemSlot in GameManager.instance.allSeedsContainer.slots)
        {
            if (itemSlot.item.Name == "corn")
            {
                corn = itemSlot.item;
            }
        }

        crops = ToolsCharacterController.fields;
        corns = new List<Corn>();
        toolbarController = GetComponent<ToolbarController>();
    }

    private void Update()
    {
        foreach(var corn in corns)
        {
            //Debug.Log(corn.position);
            Grow(corn);
        }
        
    }

    public void Mow(Vector3Int position)
    {
        groundTilemap.SetTile(position, mowed);
    }

    public void Plow(Vector3Int position)
    {
        groundTilemap.SetTile(position, plowed);
    }

    public void SeedCorn(Vector3Int position)
    {
        Corn cornSeeded = Instantiate(corn);
        
        cornSeeded.position = position;
        cornSeeded.state = cornSeeded.state0;
        cornSeeded.timeRemaining = 10;

        corns.Add(cornSeeded);
        cornSeeded.timerIsRunning = true;
        // Debug.Log(DisplayTime(cornSeeded.timeRemaining));
        cropTilemap.SetTile(cornSeeded.position, cornSeeded.state0);
        
    }

    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Grow(Corn corn)
    {
        if (corn.timerIsRunning)
        {
            if (corn.timeRemaining > 0)
            {
                corn.timeRemaining -= Time.deltaTime;
                //Debug.Log(DisplayTime(corn.timeRemaining));
            }
            else
            {
                if (corn.state == corn.state0)
                    corn.state = corn.state1;
                else if (corn.state == corn.state1)
                    corn.state = corn.state2;
                else if (corn.state == corn.state2)
                    corn.state = corn.state3;
                else if (corn.state == corn.state3)
                    corn.state = corn.state4;
                else if (corn.state == corn.state4)
                    corn.state = corn.state5;

                cropTilemap.SetTile(corn.position, corn.state);
                

                if (corn.state == corn.state5)
                {
                    corn.timerIsRunning = false;
                }
                else
                {
                    corn.timeRemaining = 10;
                    corn.timerIsRunning = true;
                }
            }
        }
    }

}