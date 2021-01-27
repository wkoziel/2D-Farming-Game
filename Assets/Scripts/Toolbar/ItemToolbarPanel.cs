using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] ToolbarController toolbarController;
    int currentSelectedTool;

    private void Start()
    {
        Init();
        Highlight(0);       // Highlights the first item on the list
    }

    // Choosing a new item in the toolbar
    public override void OnClick(int id)
    {
        toolbarController.Set(id);
        Highlight(id);
        
    }

    // Responsible for highlighting the button and hiding the previously selected highlight
    public void Highlight(int id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
