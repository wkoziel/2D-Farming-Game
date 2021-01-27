using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireReaction : CampFireHit
{
    public float time;
    public GameObject fire;
    GameObject toolbar;

    private void Start()
    {
        toolbar = GameObject.FindWithTag("toolbar");
    }
    public override void Hit()
    {
        fire.SetActive(true);

        GameManager.instance.inventoryContainer.RemoveItem(GameManager.instance.toolbarControllerGlobal.GetItem, 10);

        toolbar.SetActive(!toolbar.activeInHierarchy);
        toolbar.SetActive(true);

        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(120);
        fire.SetActive(false);
    }
}
