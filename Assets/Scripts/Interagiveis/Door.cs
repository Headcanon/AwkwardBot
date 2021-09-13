using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public GameObject door;

    public override void Interact(Transform t)
    {
        door.SetActive(false);
    }
}
