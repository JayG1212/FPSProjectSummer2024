// Written by Jay Gunderson
// 06/09/2024

/*
 Update - 06/09/2024:
 This code succesfully gives the player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Declares the variable that will represent the speed of the player
    public float speed = 5f;

    // Declares the variable taht will represent the running speed of the player
    public float runSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the input from the A and D keys, and the left and right arrows
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        // Gets the input from the W and S keys, and the up and down arrows
        float moveVertical = Input.GetAxis("Vertical");

        // Check if the left shift key (Which represents run) is being pressed 
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed;


        // Checks if isRunning is true, and if so will set current speed to runspeed
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
    }
}
