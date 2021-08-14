using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;
    public bool canMove = true;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x<0)
        {
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);

        }
        else GetComponent<Transform>().localScale = new Vector3(1, 1, 1);

    }

    void FixedUpdate()
    {
        if (canMove) rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
    }

    public void StopMovement()
    {
        canMove = false;
    }
}
