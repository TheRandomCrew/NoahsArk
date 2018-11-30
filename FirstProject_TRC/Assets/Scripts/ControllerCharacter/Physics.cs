using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {
        
    public Joystick joystick;
    public GameObject ModelCharacter;

    [SerializeField] private float health = 100f;
    [SerializeField] private float speed;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float forceJump = 100f;


    private Vector3 Movement;
    private Animator animator;
    private CharacterController characterController;
   

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = ModelCharacter.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //Physics Movement in axis x
        float moveHorizontal = joystick.Horizontal;

        if (moveHorizontal != 0)
        {
            ModelCharacter.transform.localScale = new Vector3(ModelCharacter.transform.localScale.x, ModelCharacter.transform.localScale.y, 1f * (Mathf.Sign(moveHorizontal)));

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

        Movement = new Vector3 (speed * moveHorizontal, -gravity, 0f);        
        characterController.Move(Movement * Time.deltaTime);
    }

    public void Jump()
    {
        animator.SetTrigger("IsJumping");
        Movement = new Vector3(0f, forceJump, 0f);
        characterController.Move(Movement * Time.deltaTime);
        
    }
}
