using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    // We can later change it in the inspector because it's serialized

    [SerializeField] int toolbarSize = 8;
    int selectedTool;                               // Holds the id of the selected tool

    // Scroll functionality?
   

    internal void Set(int id)
    {
        selectedTool = id;
    }
    

}
