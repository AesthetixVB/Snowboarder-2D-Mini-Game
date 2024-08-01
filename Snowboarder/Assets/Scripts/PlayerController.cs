using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;


    [Header("Movement System")]
    [SerializeField] float torqueAmount;
    [SerializeField] float boostSpeed;
    [SerializeField] float baseSpeed;
    bool canMove = true;
    
    [Header("Jump System")]
    [SerializeField] float jumpPower; 
    [SerializeField] float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector2 vecGravity;


    // Audio Manager
    AudioManager audioManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }


    void Update()
    {

        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
            JumpPlayer();
        }

    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void JumpPlayer()
    {
        
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);

        }
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity -= vecGravity * fallMultiplier * Time.deltaTime; 
        }

    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(2.9f, 0.25f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

}
