using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUpdateScript : MonoBehaviour
{
    Text count;
    ToolbarController toolbarController;
    public int countValue;

    // Start is called before the first frame update
    void Start()
    {
        toolbarController = GetComponent<ToolbarController>();
        count = GetComponent<Text>();
        //Debug.Log("Wybrany item: " + toolbarController.GetItem.Name);
    }

    ////// Update is called once per frame
    void Update()
    {
        //countValue = toolbarController.GetCount;

        //if (toolbarController.GetItem.stackable)
        //{
        //    Debug.Log("countValue: " + toolbarController.GetCount);
        //    count.text = toolbarController.GetCount.ToString();
        //}
        
    }
}
