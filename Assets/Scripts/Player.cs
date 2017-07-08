using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public float Speed { get; private set; }
    public float Euphoria { get; private set; }
    public LayerMask groundLayer;
    public Collider col;
    Animator anim;
    float jumpSpeed = 20f;
    float gravityForce = 30f;
    float incEuphoria = 0.3f;
    float decEuphoria = -0.5f;
    float normalSpeed = 150f;
    float sprintSpeed = 200f;
    bool touchingGround;
    bool jumpPressed;
    bool dead;
    Rigidbody rb;

	void Start () {
        Speed = normalSpeed;
        Euphoria = 0.5f;  //Between 0 and 1
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        dead = false;
        jumpPressed = false;
	}
	
	void Update () {
        if (CustomInput.JumpButtonDown())
        {
            jumpPressed = true;
        }
        if (!dead)
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
        //Sprinting
        if (CustomInput.SpeedUpButton())
        {
            Euphoria += Time.deltaTime * incEuphoria;
            anim.Play("Sprint");
            Speed = sprintSpeed;
        }
        //Not sprinting
        else
        {
            Euphoria += Time.deltaTime * decEuphoria;
            anim.Play("Run");
            Speed = normalSpeed;
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
        dead = true;
        Speed = 0f;
        anim.Play("Trip");
    }

    void GroundDetection()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        touchingGround = Physics.Raycast(r, col.bounds.extents.y + 0.1f, groundLayer);
    }
}