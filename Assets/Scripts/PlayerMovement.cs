using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //holds the character controller component.
    public CharacterController controller;

    //how fast the player moves
    public float moveSpeed = 12f;
    //how fast the player falls
    public float gravity = -9.81f;
    //how high the player can jump
    public float jumpHeight = 3f;

    //used in checking if the player is on the ground.
    //groundcheck is the position on the bottom of the player which is checked if it's on the ground.
    public Transform groundCheck;
    //how big the area is to check for ground in.
    public float groundDistance = 0.4f;
    //masks out objects that we could collide with but aren't the ground (namely the player.)
    public LayerMask groundMask;
    private bool isGrounded;

    //the player object's velocity
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //Checks if the player is on the ground or not
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //if the player is on the ground, resets their downward velocity. This prevents
        //constantly building up speed due to gravity.
        //this is -2 rather than zero to avoid potential errors with uneven ground geometry.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Gets movement input (unity default is WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Calculate the player's movement direction.
        Vector3 move = transform.right * x + transform.forward * z;
        //move the player using the above value
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //apply gravity to the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
