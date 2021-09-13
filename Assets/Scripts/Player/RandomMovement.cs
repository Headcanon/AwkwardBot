using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    public bool randomHorizontalMovement;
    public bool randomVerticalMovement;

    public float velocity;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = 0, xMove = 0;

        if (randomHorizontalMovement)
        {
            xMove = AutoHorizontal() * velocity;
        }
        if (randomVerticalMovement)
        {
            yMove = AutoVertical() * velocity;
        }

        rb.velocity = new Vector2(xMove, yMove);
    }

    private float speed = 1;
    private float AutoHorizontal()
    {
        RaycastHit2D hitRight;
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, distance);
        if (hitRight)
        {
            speed = -1;
        }

        RaycastHit2D hitLeft;
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance);
        if (hitLeft)
        {
            speed = 1;
        }

        return speed;
    }
    private float AutoVertical()
    {
        RaycastHit2D hitRight;
        hitRight = Physics2D.Raycast(transform.position, Vector2.up, distance);
        if (hitRight)
        {
            //Debug.Log("oi");
            speed = -1;
        }

        RaycastHit2D hitLeft;
        hitLeft = Physics2D.Raycast(transform.position, Vector2.down, distance);
        if (hitLeft)
        {
            speed = 1;
        }

        return speed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(distance, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-distance, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -distance));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, distance));
    }
}
