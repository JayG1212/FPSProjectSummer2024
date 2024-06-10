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


        // Creates a movement vector based on input, speed and frame time.
        // "new Vector3(moveHorizontal,0.0f, moveVertical)" represents the direction the player wants to move
        //  "* speed"  will multiply the direction vector to control how fast the player moves
        // "* Time.deltaTime" ensures that the movement is the same across different frame rates, making the movement independent of it
        // So the movment variable will be the directional vector multiplied by the speed variable and tthen multiplied by the deltaTime
        // movement is a Vector that represents the direction and magnitude by which we want to move the player. 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;


        // "transform.Translate(movement)"  moves the player by the movement vector ensuring consistent player movement
        // "transform" references in this case the players position, while ".Translate" updates the position by the movement vector
        // By calling "transform.Translate(movement)" each frame, we move the player according to the input received
        transform.Translate(movement);
    }
}
