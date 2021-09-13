using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header ("Movement")]
    public bool horizontalMovement;
    public bool verticalMovement;
    public bool randomHorizontalMovement;
    public bool randomVerticalMovement;

    public float velocity;
    public float distance;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = 0, xMove = 0;

        if (horizontalMovement)
        {
            xMove = Input.GetAxis("Horizontal") * velocity;
        }
        if (verticalMovement)
        {
            yMove = Input.GetAxis("Vertical") * velocity;
        }

        anim.SetFloat("Horizontal", xMove);
        anim.SetFloat("Vertical", yMove);

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
        if(hitRight)
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
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(distance,0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-distance, 0));
    }
}
