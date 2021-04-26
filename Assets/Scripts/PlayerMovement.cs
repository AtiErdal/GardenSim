using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator anim;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        Move();
        
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = transform.right * x + transform.forward * z;

        if (moveDirection != Vector3.zero)
        {
            controller.Move(moveDirection * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            Movement();
        }
        else
        {
            Idle();
        }
    }

    private void Movement()
    {
        anim.SetFloat("Speed", 0.5f);
    }
    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

}
