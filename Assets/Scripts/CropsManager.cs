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

    Dictionary<Vector2Int, TileData> crops = new Dictionary<Vector2Int, TileData>();

    TileBase seeded;
    List<Corn> corns;
    public GameObject cornPrefab;
    Corn corn;

    private void Start()
    {
        crops = ToolsCharacterController.fields;
        corns = new List<Corn>();
        corn = new Corn();
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
        corn = ScriptableObject.CreateInstance<Corn>();
        Debug.Log(corn.state0);
        corns.Add(corn);
        Instantiate(cornPrefab, position, Quaternion.identity);
        corn.timerIsRunning = true;
        cropTilemap.SetTile(position, corn.state0);
    }



    /*public void SeedCorn(Vector3Int position)
    {
        cropTilemap.SetTile(position, seeded_corn);
    }

    public void SeedParsley(Vector3Int position)
    {
        cropTilemap.SetTile(position, seeded_parsley);
    }

    public void SeedPotato(Vector3Int position)
    {
        cropTilemap.SetTile(position, seeded_potato);
    }

    public void SeedStrawberry(Vector3Int position)
    {
        cropTilemap.SetTile(position, seeded_strawberry);
    }

    public void SeedTomato(Vector3Int position)
    {
        cropTilemap.SetTile(position, seeded_tomato);
    }*/

    /*public void Seed(Vector3Int position)
    {
        seeded = corn.state0;
        cropTilemap.SetTile(position, seeded);
    }*/
}