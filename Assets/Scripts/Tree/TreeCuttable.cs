using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.9f;
    [SerializeField] int hitCount = 0;

    public override void Hit()
    {
        
        FindObjectOfType<SoundManager>().Play("Cut");
        hitCount++;
        if (hitCount >= 3){
            MoneyController.money += 30;

            // Spawning wood
            while (dropCount > 0)
            {
                dropCount -= 1;

                // Calculating where logs will drop
                Vector3 position = transform.position;
                position.x -= spread * UnityEngine.Random.value - spread / 2;
                position.y -= spread * UnityEngine.Random.value - spread / 2;
                GameObject log = Instantiate(pickUpDrop);
                log.transform.position = position;
            }

            Destroy(gameObject);
        }       
    }
}
