using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-0.1f);
        }
    }
}
