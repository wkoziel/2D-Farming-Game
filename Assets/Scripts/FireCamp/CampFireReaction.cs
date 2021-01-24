using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireReaction : CampFireHit
{
    public float time;
    public GameObject fire;
    public override void Hit()
    {
        fire.SetActive(true);
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(60);
        fire.SetActive(false);
    }
}
