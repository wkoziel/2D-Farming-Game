using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInteraction : MonoBehaviour
{
    public bool playerInRange;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            panel.SetActive(!panel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            panel.SetActive(false);
            toolbarPanel.SetActive(true);

        }
    }
}
