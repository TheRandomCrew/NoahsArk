using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {
        
    public Joystick joystick;

    [SerializeField] private float health = 100f;
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    private Animator animator;
    private Rigidbody rigibody;    

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        //Physics Movement in axis x
        float moveHorizontal = joystick.Horizontal;

        if (moveHorizontal != 0)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f*(Mathf.Sign(moveHorizontal)));

            if (Mathf.Abs(moveHorizontal) < 0.4f)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsRunning", false);
                speed = 2f;
            } else
            {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsWalking", false);
                speed = 8f;
            }           

        } else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
            speed = 0;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rigibody.velocity = movement * speed;

        //Physics Movement in axis x
        float moveVertical = joystick.Vertical;

        if (moveVertical >= 0.5f)
        {            
            animator.SetTrigger("IsJumping");
        }

    }
}
