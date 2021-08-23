using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float jumpAmount = 300f;
    public float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 direction = input.normalized;
        Vector3 movement = direction * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(new Vector2(0, jumpAmount));
        }
        transform.Translate(movement * Time.deltaTime);
    }
}
