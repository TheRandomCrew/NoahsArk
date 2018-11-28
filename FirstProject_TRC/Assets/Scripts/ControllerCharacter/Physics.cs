using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {

    public float speed;

    private Animator animator;
    private Rigidbody rigibody;


    private void Awake()
    {
        rigibody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        animator.SetBool("IsWalking", false);
        if (moveHorizontal != 0)
        {
            if (moveHorizontal < 0) gameObject.transform.localScale = new Vector3(1f, 1f, -1f);
            else if (moveHorizontal > 0) gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("IsWalking", true);
            
        }
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rigibody.velocity = movement * speed;

    }
}
