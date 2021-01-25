using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public bool playerInRange;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;

    [SerializeField] GameObject openedChest;
    [SerializeField] GameObject closedChest;
    [SerializeField] bool opened;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetMouseButtonDown(0)) // lewy przycisk myszki
        {
            Debug.Log("clicking on chest");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Interact()
    {
        if (opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    playerInRange = true;
        //    //panel.SetActive(!panel.activeInHierarchy);
        //    panel.SetActive(false);
        //    toolbarPanel.SetActive(true);
        //    //toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    playerInRange = false;
        //    //panel.SetActive(false);
        //    //toolbarPanel.SetActive(true);

        //}
    }
}
