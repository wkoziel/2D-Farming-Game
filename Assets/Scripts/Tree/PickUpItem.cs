using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;  // speed of moving the object towards the player
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    [SerializeField] Item item;
    public int count = 1;


    GameObject toolbar;

    private void Start()
    {
        player = GameManager.instance.player.transform;
        toolbar = GameObject.FindWithTag("toolbar");
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // if the player is not in the distance to pick up logs no function is executed
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);

                toolbar.SetActive(!toolbar.activeInHierarchy);
                toolbar.SetActive(true);

                //Debug.Log(GameManager.instance.toolbarControllerGlobal.GetItem.Name);
            }
            else
            {
                Debug.LogWarning("no inventory container attached to game manager");
            }

            Destroy(gameObject);
            
        }
    }
}
