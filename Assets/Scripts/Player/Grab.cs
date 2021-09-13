using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private Grabable grabed;

    public LayerMask interactableLayer;
    public float radius;
    public Transform holdPoint;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (grabed == null)
            {
                Collider2D[] cols;
                cols = Physics2D.OverlapCircleAll(transform.position, radius, interactableLayer);
                foreach (Collider2D col in cols)
                {
                    col.GetComponent<Interactable>().Interact(transform);

                    if (col.CompareTag("Grabable"))
                    {
                        col.transform.position = holdPoint.position;
                        col.transform.SetParent(transform);
                        grabed = col.GetComponent<Grabable>();
                    }
                }
            }
            else
            {
                grabed.transform.parent = null;
                grabed = null;
            }            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
