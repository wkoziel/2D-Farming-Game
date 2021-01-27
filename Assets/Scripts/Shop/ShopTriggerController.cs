using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerController : MonoBehaviour
{
    [SerializeField] private UI_ShopController uiShop;
    
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        uiShop.Show();
        FindObjectOfType<SoundManager>().Play("Parrot");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        uiShop.Hide();
    }
}
