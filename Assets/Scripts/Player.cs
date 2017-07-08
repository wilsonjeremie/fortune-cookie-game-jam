using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public float Speed { get; private set; }
    public LayerMask groundLayer;
    float jumpSpeed = 10f;
    float gravityForce = 20f;
    float euphoria;
    bool touchingGround;
    bool jumpPressed;
    Rigidbody rb;
    Collider col;

	void Start () {
        Speed = 150f;
        euphoria = 0f;  //Between -1 and 1
        rb = GetComponent<Rigidbody>();
        
        jumpPressed = false;
	}
	
	void Update () {
        if (CustomInput.JumpButtonDown())
        {
            jumpPressed = true;
        }
	}

    void FixedUpdate()
    {
        GroundDetection();

        if (jumpPressed && touchingGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
        if (!touchingGround) rb.AddForce(Vector3.down * gravityForce, ForceMode.Acceleration);
        jumpPressed = false;
    }

    void GroundDetection()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        touchingGround = Physics.Raycast(r, 0.6f, groundLayer);
    }
}
