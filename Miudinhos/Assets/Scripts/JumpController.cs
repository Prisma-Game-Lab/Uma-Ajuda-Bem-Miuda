using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour

{
    //declare referenc variables
    public CharacterController characterController;
    public PlayerInput playerInput;
    //public CurrentMovement currentMovement;
    //public CurrentRunMovement currentRunMovement;

    // jumping variables
    private bool isJumpPressed = false;
    private float initialJumpVelocity;
    float maxJumpHight = 1.0f;
    private float maxJumpTime = 0.5f;
    private bool isJumping;

    //gravity variables and function
    private float gravity = -9.8f;
    private float groundedGravity = -.05f;

    void handleGravity(){}
    {
        if(characterController.isGrounded)
        {
            currentMovement.y = groundedGravity;
            //currentRunMovement.y = groundedGravity;
        }
        else()
        {
            currentMovement.y += gravity * Time.deltaTime;
            currentRunMovement.y += gravity * Time.deltaTime;
        }
    }

    //set the players inputs callback
    void Awake()
    {
        playerInput.CharacterControls.Jump.started += onJump;
        playerInput.CharacterControls.Jump.canceled += onJump;

        setupJumpVariables();
    }
    void setupJumpVariables()
    {
        float timeToApex = maxJumpHight/2;
        gravity = (-2 * maxJumpHight)/Mathf.Pow(timeToApex,2);
        inetialJumpVelocity = (2 * maxJumpHight)/timeToApex;
    }
    void handleJump()
    {
        if(!isJumping && characterController.isGrounded && isJumpPressed)
        {
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
            //currentRunMovement.y = initialJumpVelocity;

        }else if (!isJumpPressed && isJumping && characterController.isGrounded)
        {
            isJumping = false;
        }

    }

    void onJump (InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
        //Debug.Log(isJumpPressed);
    }
    void Update()
    {
        handleGravity();
        handleJump();
    }
}
