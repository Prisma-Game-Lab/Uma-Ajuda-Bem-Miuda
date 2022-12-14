using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float rotationSpeed = 720.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.minMoveDistance = 0;

        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    //Trata dos pulos do player
    private void Update()
    {
       

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (playerInput.actions["Jump"].triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        groundedPlayer = controller.isGrounded;
    }

    //Trata da movimentação
    void FixedUpdate()
    {

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0f, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        if (move != Vector3.zero)
        {
            this.gameObject.transform.forward = -move;
            //Quaternion toRotation = Quaternion.LookRotation(-move, Vector3.up);
            //controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    } 
}
