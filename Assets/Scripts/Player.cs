using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public float Speed { get; private set; }
    public float Euphoria { get; private set; }
    public LayerMask groundLayer;
    float jumpSpeed = 10f;
    float gravityForce = 20f;
    float incEuphoria = 0.3f;
    float decEuphoria = -0.5f;
    bool touchingGround;
    bool jumpPressed;
    Rigidbody rb;
    Collider col;

	void Start () {
        Speed = 150f;
        Euphoria = 0.5f;  //Between 0 and 1
        rb = GetComponent<Rigidbody>();
        
        jumpPressed = false;
	}
	
	void Update () {
        if (CustomInput.JumpButtonDown())
        {
            jumpPressed = true;
        }
        UpdateEuphoria();
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

    void UpdateEuphoria()
    {
        if (CustomInput.SpeedUpButton())
        {
            Euphoria += Time.deltaTime * incEuphoria;
        }
        else
        {
            Euphoria += Time.deltaTime * decEuphoria;
        }
        Euphoria = Mathf.Clamp(Euphoria, 0f, 1f);

        //Death if euphoria < 0f
        if (Euphoria <= 0f)
        {
            Death();
        }
    }

    void Death()
    {

    }

    void GroundDetection()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        touchingGround = Physics.Raycast(r, 0.6f, groundLayer);
    }
}