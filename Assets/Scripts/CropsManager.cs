using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase grass;
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase mowed;
    [SerializeField] TileBase toWater;
    [SerializeField] TileBase watered;
    [SerializeField] TileBase invisible;
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] Tilemap cropTilemap;
    ToolbarController toolbarController;

    Dictionary<Vector2Int, TileData> fields = new Dictionary<Vector2Int, TileData>();

    public Dictionary<Vector3Int, Crop> crops;
    //Crop crop;
    public Dictionary<Vector3Int, Crop> corns;
    Crop corn;
    public Dictionary<Vector3Int, Crop> parsleys;
    Crop parsley;
    public Dictionary<Vector3Int, Crop> potatoes;
    Crop potato;
    public Dictionary<Vector3Int, Crop> strawberries;
    Crop strawberry;
    public Dictionary<Vector3Int, Crop> tomatoes;
    Crop tomato;

    private void Awake()
    {
        //crop = ScriptableObject.CreateInstance<Crop>();
        corn = ScriptableObject.CreateInstance<Crop>();
        parsley = ScriptableObject.CreateInstance<Crop>();
        potato = ScriptableObject.CreateInstance<Crop>();
        strawberry = ScriptableObject.CreateInstance<Crop>();
        tomato = ScriptableObject.CreateInstance<Crop>();

    }

    private void Start()
    {
        // Looking for the crop item in the game
        foreach (SeedSlot itemSlot in GameManager.instance.allSeedsContainer.slots)
        {
            if (itemSlot.item.Name == "corn")
            {
                corn = itemSlot.item;
            }
            else if (itemSlot.item.Name == "parsley")
            {
                parsley = itemSlot.item;
            }
            else if (itemSlot.item.Name == "potato")
            {
                potato = itemSlot.item;
            }
            else if (itemSlot.item.Name == "strawberry")
            {
                strawberry = itemSlot.item;
            }
            else if (itemSlot.item.Name == "tomato")
            {
                tomato = itemSlot.item;
            }
        }

        fields = ToolsCharacterController.fields;

        crops = new Dictionary<Vector3Int, Crop>();
        corns = new Dictionary<Vector3Int, Crop>();
        parsleys = new Dictionary<Vector3Int, Crop>();
        potatoes = new Dictionary<Vector3Int, Crop>();
        strawberries = new Dictionary<Vector3Int, Crop>();
        tomatoes = new Dictionary<Vector3Int, Crop>();


        toolbarController = GetComponent<ToolbarController>();
    }

    private void Update()
    {
        foreach (var crop in crops.Values)
            Grow(crop); //updating time of growth
    }

    public void Mow(Vector3Int position)
    {
        groundTilemap.SetTile(position, mowed);
    }

    public void Plow(Vector3Int position)
    {
        groundTilemap.SetTile(position, plowed);
    }

    public void SeedCrop(Vector3Int position, string name)
    {
        Crop cropSeeded;
        //depended on what plant we want to seed
        if (name == "corn")
        {
            cropSeeded = Instantiate(corn); //clone sample corn
            cropSeeded.position = position; //assign a position
            cropSeeded.state = cropSeeded.state0; //assign initial state
            cropSeeded.timeRemaining = 120; //assign time to grow

            crops.Add(position, cropSeeded); //add to dictionary of all crops
            corns.Add(position, cropSeeded); //add to dictionary of all corns
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0); //change a tile on tilemap with crops
        }
        else if (name == "parsley")
        {
            cropSeeded = Instantiate(parsley);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 60;

            crops.Add(position, cropSeeded);
            parsleys.Add(position, cropSeeded);
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        else if (name == "potato")
        {
            cropSeeded = Instantiate(potato);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 90;

            crops.Add(position, cropSeeded);
            potatoes.Add(position, cropSeeded);
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        else if (name == "strawberry")
        {
            cropSeeded = Instantiate(strawberry);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 90;

            crops.Add(position, cropSeeded);
            strawberries.Add(position, cropSeeded);
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        else if (name == "tomato")
        {
            cropSeeded = Instantiate(tomato);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 60;

            crops.Add(position, cropSeeded);
            tomatoes.Add(position, cropSeeded);
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        groundTilemap.SetTile(position, toWater); //change a tile on tilemap with ground
    }

    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Water(Vector3Int position)
    {
        crops[position].timerIsRunning = true; //init a timer - plant can grow
        groundTilemap.SetTile(position, watered); //change a tile on tilemap with gorund
        //Debug.Log(crops[position].timeRemaining);

    }

    void Grow(Crop crop)
    {
        if (crop.timerIsRunning) //if watered - timer is running
        {
            if (crop.timeRemaining > 0)
            {
                crop.timeRemaining -= Time.deltaTime; //counting down
                //Debug.Log(DisplayTime(crop.timeRemaining));
            }
            else
            {
                if (crop.name == "Parsley(Clone)") //parsley has less states of grow
                {
                    //update state
                    if (crop.state == crop.state0)
                        crop.state = crop.state1;
                    else if (crop.state == crop.state1)
                        crop.state = crop.state2;
                    else if (crop.state == crop.state2)
                        crop.state = crop.state3;
                    else if (crop.state == crop.state3)
                        crop.state = crop.state4;

                    cropTilemap.SetTile(crop.position, crop.state); //change a tile on tilemap with crops to next state
                    groundTilemap.SetTile(crop.position, toWater); //change a tile on tilemap with ground to waterable


                    crop.timerIsRunning = false; //timer stops counting
                    if (crop.state != crop.state4)
                    {
                        crop.timeRemaining = 60; //time to next state
                    }
                }
                else
                {
                    //update state
                    if (crop.state == crop.state0)
                        crop.state = crop.state1;
                    else if (crop.state == crop.state1)
                        crop.state = crop.state2;
                    else if (crop.state == crop.state2)
                        crop.state = crop.state3;
                    else if (crop.state == crop.state3)
                        crop.state = crop.state4;
                    else if (crop.state == crop.state4)
                        crop.state = crop.state5;

                    cropTilemap.SetTile(crop.position, crop.state); //change a tile on tilemap with crops to next state
                    groundTilemap.SetTile(crop.position, toWater); //change a tile on tilemap with ground to waterable

                    crop.timerIsRunning = false; //timer stops counting
                    if (crop.state != crop.state5)
                    {
                        if (crop.name == "Corn(Clone)")
                            crop.timeRemaining = 120; //time to next state
                        if (crop.name == "Potato(Clone)")
                            crop.timeRemaining = 90; //time to next state
                        if (crop.name == "Strawberry(Clone)")
                            crop.timeRemaining = 90; //time to next state
                        if (crop.name == "Tomato(Clone)")
                            crop.timeRemaining = 60; //time to next state
                    }
                }

            }
        }
    }

    public void Collect(Vector3Int position, string name)
    {
        //depending on what plant we want to collect
        if (name == "corn")
        {
            cropTilemap.SetTile(position, invisible); //set tile on tilemap with crops to unplanted
            Destroy(corns[position]); //destroy object of corn
            corns.Remove(position); //remove element of dictionary with corns
        }
        else if (name == "parsley")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(parsleys[position]);
            parsleys.Remove(position);
        }
        else if (name == "potato")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(potatoes[position]);
            potatoes.Remove(position);
        }
        else if (name == "strawberry")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(strawberries[position]);
            strawberries.Remove(position);
        }
        else if (name == "tomato")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(tomatoes[position]);
            tomatoes.Remove(position);
        }
        crops.Remove(position); //remove element of dictionary with all crops
        MoneyController.money += 20;

        int texture = UnityEngine.Random.Range(0, 2); //random int - 0 or 1
        if (texture == 0)
            groundTilemap.SetTile(position, mowed); //if random in == 0 - change tile on tilemap with ground to dirt
        else
            groundTilemap.SetTile(position, grass); //if random in == 1 - change tile on tilemap with ground to grass

    }
}