using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;
    public bool isOpen = false;
    GameObject dialogue;

    private void Start()
    {
        dialogue = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("startDialogue"));
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        // Opens/closes inventory after clicking E (equipment) on keyboard
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
