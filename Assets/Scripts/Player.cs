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
    public GroundDetection gd;
    public GroundDetection wd;
    public LayerMask groundLayer;
    public Collider col;
    public GameObject brokenCrystalPrefab;
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
    bool airFlag;
    Rigidbody rb;

	void Start () {
        Speed = normalSpeed;
        Euphoria = 0.75f;  //Between 0 and 1
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        airFlag = false;

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
        if (jumpPressed && touchingGround && !Dead)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            attacking = false;
        }
        if (!touchingGround) rb.AddForce(Vector3.down * gravityForce, ForceMode.Acceleration);
        jumpPressed = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Death")
        {
            Euphoria = 0f;
            Death();
        }
        else if (col.gameObject.tag == "Crystal")
        {
            if (attacking)
            {
                CreateBrokenCrystal(col.gameObject);
                Euphoria += 0.1f;
            }
            else
            {
                Euphoria = 0f;
                Death();
            }
        }
    }

    void CreateBrokenCrystal(GameObject otherCrystal)
    {
        GameObject brokenCrystal = Instantiate(brokenCrystalPrefab, otherCrystal.transform.position, otherCrystal.transform.rotation) as GameObject;
        Destroy(brokenCrystal, 2f);
        Destroy(otherCrystal);

        GetComponent<AudioSource>().Play();
    }

    void Attack()
    {
        if (!attacking)
        {
            anim.Play("Charge");
            attacking = true;
        }
    }

    void StopAttacking()
    {
        attacking = false;
        if (!touchingGround)
            anim.Play("Jump Down");
    }

    void UpdateEuphoria()
    {
        if (GameController.GamePaused) return;
        //Sprinting
        if (CustomInput.SpeedUpButton())
        {
            Euphoria += Time.deltaTime * incEuphoria;
            if (!attacking && touchingGround) anim.Play("Sprint");
            {
                Speed = (attacking) ? sprintSpeed * 1.5f : sprintSpeed;
            }
        }
        //Not sprinting
        else
        {
            if (touchingGround)
                Euphoria += Time.deltaTime * decEuphoria;
            else
                Euphoria += Time.deltaTime * decEuphoria * 0.3f;

            if (!attacking && touchingGround) anim.Play("Run");
            Speed = (attacking) ? normalSpeed * 1.5f : normalSpeed;
        }
        if (!touchingGround && !attacking && !Dead && !airFlag)
        {
            anim.Play("Jump Up");
            airFlag = true;
        }
        if (touchingGround)
            airFlag = false;
        Euphoria = Mathf.Clamp(Euphoria, 0f, 1f);

        anim.SetBool("Falling", rb.velocity.y < 0f);

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
        //Ray r = new Ray(transform.position, Vector3.down);
        //touchingGround = Physics.Raycast(r, col.bounds.extents.y + 0.1f, groundLayer);

        touchingGround = gd.touchingGround;

        if (wd.touchingGround)
        {
            Euphoria = 0f;
            Death();
        }
    }
}