using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnesPlayer : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float jumpAmount = 300f;
    public float speed = 7f;
    bool Grounded = false;
    Vector2 input = new Vector2();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            playerRigidbody.velocity = new Vector2(0, jumpAmount * Time.fixedDeltaTime);
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = HandleInput(KeyCode.A, KeyCode.D);
        playerRigidbody.position += movement * Time.fixedDeltaTime;
    }

    Vector2 HandleInput(KeyCode leftKey = KeyCode.A, KeyCode rightKey = KeyCode.D)
    {
        if (Input.GetKey(leftKey)) input.x = -1;
        else if (Input.GetKey(rightKey)) input.x = 1;
        else input.x = 0;

        Vector2 direction = input.normalized;
        Vector2 movement = direction * speed;
        return movement;
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        Grounded = false;
    }

    void CheckIfGrounded()
    {
        RaycastHit2D[] hits;

        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        if (hits.Length > 0)
        {
            Grounded = true;
        }
    }

}
