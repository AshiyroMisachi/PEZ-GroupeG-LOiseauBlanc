using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//This Script need a CharacterController to work, CharacterController work like a Collider
[RequireComponent(typeof(CharacterController))]
public class S_PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    //speed value of the player
    public float speed = 12f;
    //Jump heigth value of the player
    public float jumpHeight = 3f;

    //Reference of the CharacterController
    private CharacterController controller;

    [Header("Gravity")]
    //CharacterController and Rigidbody are not compatible so we need  to create a self gravity for the player
    //Stock the velocity of the player
    private Vector3 velocity;
    //The Gravity who gonna be apply to the player 
    public float gravity = -9.81f;


    [Header("GroundCheck")]
    //All the variable needed for checking if the player is touching the ground
    //The transform of a empty gameobject
    public Transform groundCheck;
    //Radius of the checking sphere
    public float groundDistance = 0.04f;
    //Mask for the ground
    public LayerMask groundMask;
    //Stock if the player touch the ground or not
    private bool isGrounded;

    void Start()
    {
        //Get Reference from Component
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Check if the player touch the ground or not
        IsGrounded();
        //Chek if the player need to move each frame
        Movement();
        //Apply the gravity to the player
        PlayerGravity();
    }

    private void Movement()
    {
        //Stock Axis value
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Make a vector 3 from Axis value before moving
        Vector3 move = transform.right * x + transform.forward * z;

        //Move the Player    Multiplied by the speed    And deltaTime to work with all frameRate
        controller.Move(move * speed * Time.deltaTime);
    }

    private void PlayerGravity()
    {
        //Apply the gravity to the player  multiplied by deltaTime to be frame independant 
        velocity.y += gravity * Time.deltaTime;
        //Move the player with the gravity velocity  and multiplied again with deltaTime because
        controller.Move(velocity * Time.deltaTime);
    }

    private void IsGrounded()
    {
        //Spawn a sphere at the bottom of the player, if this sphere touch a object at the ground layout, say true
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If the player touch the ground, reset the gravity velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
