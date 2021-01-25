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

    //public List<Crop> crops;
    public Dictionary<Vector3Int, Crop> crops;
    Crop crop;
    //public List<Crop> corns;
    public Dictionary<Vector3Int, Crop> corns;
    Crop corn;
    //public List<Crop> parsleys;
    public Dictionary<Vector3Int, Crop> parsleys;
    Crop parsley;
    //public List<Crop> potatoes;
    public Dictionary<Vector3Int, Crop> potatoes;
    Crop potato;
    //public List<Crop> strawberries;
    public Dictionary<Vector3Int, Crop> strawberries;
    Crop strawberry;
    //public List<Crop> tomatoes;
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
        /*foreach (SeedSlot itemSlot in GameManager.instance.allSeedsContainer.slots)
        {
            if (itemSlot.item.Name == "corn" || itemSlot.item.Name == "parsley" || itemSlot.item.Name == "potato" || itemSlot.item.Name == "strawberry" || itemSlot.item.Name == "tomato")
            {
                crop = itemSlot.item;
            }


        }*/

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
        //crops = new List<Crop>();
        /*corns = new List<Crop>();
        parsleys = new List<Crop>();
        potatoes = new List<Crop>();
        strawberries = new List<Crop>();
        tomatoes = new List<Crop>();*/

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
        /*foreach (var crop in corns.Values)
        {
            Grow(crop);
        }
        foreach (var crop in parsleys.Values)
        {
            Grow(crop);
        }
        foreach (var crop in potatoes.Values)
        {
            Grow(crop);
        }
        foreach (var crop in strawberries.Values)
        {
            Grow(crop);
        }
        foreach (var crop in tomatoes.Values)
        {
            Grow(crop);
        }*/
        foreach (var crop in crops.Values)
            Grow(crop);

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
        if (name == "corn")
        {
            cropSeeded = Instantiate(corn);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 5;

            //cropSeeded.timerIsRunning = true;
            crops.Add(position, cropSeeded);
            corns.Add(position, cropSeeded);
            //Debug.Log(DisplayTime(cropSeeded.timeRemaining));
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        else if (name == "parsley")
        {
            cropSeeded = Instantiate(parsley);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 5;

            //cropSeeded.timerIsRunning = true;
            crops.Add(position, cropSeeded);
            parsleys.Add(position, cropSeeded);
            // Debug.Log(DisplayTime(cropSeeded.timeRemaining));
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        else if (name == "potato")
        {
            cropSeeded = Instantiate(potato);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 5;

            //cropSeeded.timerIsRunning = true;
            crops.Add(position, cropSeeded);
            potatoes.Add(position, cropSeeded);
            // Debug.Log(DisplayTime(cropSeeded.timeRemaining));
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        else if (name == "strawberry")
        {
            cropSeeded = Instantiate(strawberry);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 5;

            //cropSeeded.timerIsRunning = true;
            crops.Add(position, cropSeeded);
            strawberries.Add(position, cropSeeded);
            // Debug.Log(DisplayTime(cropSeeded.timeRemaining));
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        else if (name == "tomato")
        {
            cropSeeded = Instantiate(tomato);
            cropSeeded.position = position;
            cropSeeded.state = cropSeeded.state0;
            cropSeeded.timeRemaining = 5;

            //cropSeeded.timerIsRunning = true;
            crops.Add(position, cropSeeded);
            tomatoes.Add(position, cropSeeded);
            // Debug.Log(DisplayTime(cropSeeded.timeRemaining));
            cropTilemap.SetTile(cropSeeded.position, cropSeeded.state0);
        }
        groundTilemap.SetTile(position, toWater);
    }

    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Water(Vector3Int position)
    {
        crops[position].timerIsRunning = true;
        groundTilemap.SetTile(position, watered);
    }

    void Grow(Crop crop)
    {
        if (crop.timerIsRunning)
        {
            if (crop.timeRemaining > 0)
            {
                crop.timeRemaining -= Time.deltaTime;
                //Debug.Log(DisplayTime(crop.timeRemaining));
            }
            else
            {
                if (crop.name == "Parsley(Clone)")
                {
                    if (crop.state == crop.state0)
                        crop.state = crop.state1;
                    else if (crop.state == crop.state1)
                        crop.state = crop.state2;
                    else if (crop.state == crop.state2)
                        crop.state = crop.state3;
                    else if (crop.state == crop.state3)
                        crop.state = crop.state4;

                    cropTilemap.SetTile(crop.position, crop.state);
                    groundTilemap.SetTile(crop.position, toWater);


                    if (crop.state == crop.state4)
                    {
                        crop.timerIsRunning = false;
                    }
                    else
                    {
                        crop.timeRemaining = 5;
                        crop.timerIsRunning = false;
                    }
                }
                else
                {
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

                    cropTilemap.SetTile(crop.position, crop.state);
                    groundTilemap.SetTile(crop.position, toWater);


                    if (crop.state == crop.state5)
                    {
                        crop.timerIsRunning = false;
                    }
                    else
                    {
                        crop.timeRemaining = 5;
                        crop.timerIsRunning = false;
                    }
                }

            }
        }
    }

    public void Collect(Vector3Int position, string name)
    {
        if (name == "corn")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(corns[position]);
            corns.Remove(position);
            //dodanie do eq
        }
        else if (name == "parsley")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(parsleys[position]);
            parsleys.Remove(position);
            //dodanie do eq
        }
        else if (name == "potato")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(potatoes[position]);
            potatoes.Remove(position);
            //dodanie do eq
        }
        else if (name == "strawberry")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(strawberries[position]);
            strawberries.Remove(position);
            //dodanie do eq
        }
        else if (name == "tomato")
        {
            cropTilemap.SetTile(position, invisible);
            Destroy(tomatoes[position]);
            tomatoes.Remove(position);
            //dodanie do eq
        }
        crops.Remove(position);
        int texture = UnityEngine.Random.Range(0, 2);
        if (texture == 0)
            groundTilemap.SetTile(position, mowed);
        else
            groundTilemap.SetTile(position, grass);

    }
}