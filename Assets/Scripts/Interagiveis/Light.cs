using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Interactable
{
    public SpriteRenderer sp;
    bool flip = true;

    public override void Interact(Transform t)
    {
        if (Flip())
        {
            sp.color = Color.gray;
        }
        else 
        {
            sp.color = Color.magenta;
        }
    }

    private bool Flip()
    {
        flip = !flip;
        return flip;
    }
}
