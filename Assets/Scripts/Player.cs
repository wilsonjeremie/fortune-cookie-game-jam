using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public LayerMask groundLayer;
    public float jumpSpeed = 5f;
    bool touchingGround;
    bool jumpPressed;
    Rigidbody rb;
    Collider col;

	void Start () {
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
        jumpPressed = false;
    }

    void GroundDetection()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        touchingGround = Physics.Raycast(r, 0.6f, groundLayer);
    }
}
