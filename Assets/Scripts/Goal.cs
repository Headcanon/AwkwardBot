using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameMaster gm;
    public LayerMask interactableLayer;
    public float radius;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Collider2D[] cols;
            cols = Physics2D.OverlapCircleAll(transform.position, radius, interactableLayer);
            foreach (Collider2D col in cols)
            {
                if (col.CompareTag("Grabable"))
                {
                    gm.Win();
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            Debug.Log("heck");
            gm.Win();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
