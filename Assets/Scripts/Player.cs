using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public event Action PlayerDied;
    public float Speed { get; private set; }
    public float Euphoria { get; private set; }
    public bool Dead { get; private set; }
    public LayerMask groundLayer;
    public Collider col;
    Animator anim;
    float jumpSpeed = 50f;
    float gravityForce = 120f;
    float incEuphoria = 0.1f;
    float decEuphoria = -0.5f;
    float normalSpeed = 75f;    //150
    float sprintSpeed = 150f;   //200
    bool touchingGround;
    bool jumpPressed;
    bool attacking;
    Rigidbody rb;

	void Start () {
        Speed = normalSpeed;
        Euphoria = 0.75f;  //Between 0 and 1
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Dead = false;
        jumpPressed = false;
        attacking = false;
	}
	
	void Update () {
        if (CustomInput.JumpButtonDown())
        {
            jumpPressed = true;
        }
        if (!Dead)
        {
            if (CustomInput.AttackButtonDown())
            {
                Attack();
            }
            UpdateEuphoria();
        }
	}

    void FixedUpdate()
    {
        GroundDetection();

        //Should not attack when charging?
        if (jumpPressed && touchingGround && !Dead && !attacking)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
        if (!touchingGround) rb.AddForce(Vector3.down * gravityForce, ForceMode.Acceleration);
        jumpPressed = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Crystal")
        {
            Euphoria = 0f;
            Death();
        }
    }

    void Attack()
    {
        anim.Play("Charge");
        attacking = true;
    }

    void StopAttacking()
    {
        attacking = false;
    }

    void UpdateEuphoria()
    {
        if (GameController.GamePaused) return;
        //Sprinting
        if (CustomInput.SpeedUpButton())
        {
            Euphoria += Time.deltaTime * incEuphoria;
            if (!attacking) anim.Play("Sprint");
            Speed = sprintSpeed;
        }
        //Not sprinting
        else
        {
            Euphoria += Time.deltaTime * decEuphoria;
            if (!attacking) anim.Play("Run");
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
        Dead = true;
        Speed = 0f;
        anim.Play("Trip");

        if (PlayerDied != null) PlayerDied();
    }

    void GroundDetection()
    {
        Ray r = new Ray(transform.position, Vector3.down);
        touchingGround = Physics.Raycast(r, col.bounds.extents.y + 0.1f, groundLayer);
    }
}