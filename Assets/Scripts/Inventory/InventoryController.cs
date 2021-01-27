using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Opens up the inventory after clicking I on the keyboard
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;
    public bool isOpen = false;
    GameObject dialogue;
    GameObject shop;

    private void Start()
    {
        dialogue = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("dialoguePanel"));
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (Input.GetKeyDown(KeyCode.E) && !dialogue.activeSelf)
        {
            panel.SetActive(!panel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
            if (panel.activeInHierarchy)
                isOpen = true;
            else
                isOpen = false;
        }
    }
}
