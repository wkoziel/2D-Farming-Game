using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// base script which describes virtual methods which will be
// inherited by all objects which can be struck by tools

// then create object base scripts which describe reaction of the object to this action
public class CampFireHit : MonoBehaviour
{
    public virtual void Hit()
    {

    }
}
