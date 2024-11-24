using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public BoxCollider2D myCollider;
    public float JumpStrength;
    public float MoveSpeed = 10f;
    public float characterY;

    void Update()
    {
        // Get the current velocity
        Vector2 newVelocity = myRigidbody.velocity;

        // Horizontal movement: Modify only the x component
        if (Input.GetKey(KeyCode.A))
        {
            newVelocity.x = -MoveSpeed; // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newVelocity.x = MoveSpeed; // Move right
        }
        else
        {
            newVelocity.x = 0; // Stop horizontal movement if no input
        }

        // Jumping: Only if grounded
        if (Input.GetKeyDown(KeyCode.W))
        {
            newVelocity.y = JumpStrength; // Apply jump force
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            newVelocity.y = -4 * JumpStrength; // Apply jump force
        }

        // Update the variable with the character's current y-position
        characterY = transform.position.y;

        // Log the y-position to the console (for debugging purposes)
        Debug.Log($"Character's Y Position: {characterY}");

        // Apply the combined velocity
        myRigidbody.velocity = newVelocity;
    }

}