using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : Interactable
{
    private bool flip = true;
    public override void Interact(Transform t)
    {
        //if (flip)
        //{
        //    transform.SetParent(t, true);
        //    flip = !flip;
        //}
        //else
        //{
        //    transform.parent = null;
        //    flip = !flip;
        //}
    }
}
