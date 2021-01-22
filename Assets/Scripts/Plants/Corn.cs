using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Globalization;
using UnityEngine.UI;

//[CreateAssetMenu(menuName = "Data/Corn")]

public class Corn : MonoBehaviour
{
    [SerializeField] TileBase state0;

    [SerializeField] TileBase state1;

    [SerializeField] TileBase state2;

    [SerializeField] TileBase state3;

    [SerializeField] TileBase state4;

    [SerializeField] TileBase state5;

    [SerializeField] Tilemap cropTilemap;

    TileBase state;
    Vector3Int pos;

    //private string currentTime;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;

    public void Seed(Vector3Int position)
    {
        //currentTime = Time.time.ToString("f6");
        timerIsRunning = true;
        //Debug.Log(currentTime.ToString());
        cropTilemap.SetTile(position, state0);
        state = state0;
        pos = position;
    }

    public Corn(Vector3Int position)
    {
        //currentTime = Time.time.ToString("f6");
        timerIsRunning = true;
        //Debug.Log(currentTime.ToString());
        cropTilemap.SetTile(position, state0);
        state = state0;
        pos = position;
    }

    void Update()
    {
        Grow(this);
    }

    void Grow(Corn corn)
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(DisplayTime(timeRemaining));
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

                cropTilemap.SetTile(corn.pos, corn.state);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}