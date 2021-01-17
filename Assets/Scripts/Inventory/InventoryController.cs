using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Opens up the inventory after clicking I on the keyboard
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(!panel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }
}
