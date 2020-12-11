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

        // Highlights the first item on the list
        Highlight(0);
    }

    public override void OnClick(int id)
    {
        //Show();
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
