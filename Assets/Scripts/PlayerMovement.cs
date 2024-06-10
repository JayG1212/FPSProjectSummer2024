// Written by Jay Gunderson
// 06/09/2024

/*
 Update - 06/09/2024:
 This code succesfully gives the player jumping capabilities, and prevents us from jumping in air by keeping track of whether we are grounded
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable declarations
    public float speed = 5f; // Walking speed
    public float runSpeed = 10f; // Running speed
    public float jumpForce = 8f; // Jump Force
    public bool isOnGround = false; // Status of whether the player is on ground, starts at false since the player falls at start of game
   
    private Rigidbody rb; // A rigidbody component, gives physics to player
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Retrieves the rigidbody component from the unity editor, associated with the player object
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal"); // A&D and Left/Right keys
        float moveVertical = Input.GetAxis("Vertical"); // W&S and Up/Down keys
        bool isRunning = Input.GetKey(KeyCode.LeftShift); // Check if the left shift key (Which represents run) is being pressed 


        // Checks if isRunning is true, and if so will set current speed to runspeed
        float currentSpeed; // Declares current speed
        if (isRunning)
        {
            currentSpeed = runSpeed;
        }

        else
        {
            currentSpeed = speed;
        }

        // Creates a movement vector based on input, speed and frame time.
        // "new Vector3(moveHorizontal,0.0f, moveVertical)" represents the direction the player wants to move
        //  "* currrentSpeed" will multiply the direction vector, by either run speed or just speed, to control how fast the player mov
        // "* Time.deltaTime" ensures that the movement is the same across different frame rates, making the movement independent of it
        // So the movment variable will be the directional vector multiplied by the speed variable and tthen multiplied by the deltaTime
        // movement is a Vector that represents the direction and magnitude by which we want to move the player. 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * currentSpeed * Time.deltaTime;


        // "transform.Translate(movement)"  moves the player by the movement vector ensuring consistent player movement
        // "transform" references in this case the players position, while ".Translate" updates the position by the movement vector
        // By calling "transform.Translate(movement)" each frame, we move the player according to the input received
        transform.Translate(movement);

        

        // Jump Controls
       
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround) // Checks if the jump button (Spacebar) is pressed, and if the player is on the ground
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // We add force to our player based off of our jump force
            isOnGround = false; // So we can't jump midair
        }
    }

    private void OnCollisionEnter(Collision collision) // Whenever our object collides with something this is called
    {
        if (collision.gameObject.CompareTag("Ground")) // If our player collides with an object tagged "Ground"
        {
            isOnGround = true; // We can jump again
        }
    }


}
