using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC2Script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public BoxCollider2D myCollider;
    public float JumpStrength;
    public float MoveSpeed = 10f;

    void Update()
    {
        // Get the current velocity
        Vector2 newVelocity = myRigidbody.velocity;

        // Horizontal movement: Modify only the x component
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newVelocity.x = -MoveSpeed; // Move left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newVelocity.x = MoveSpeed; // Move right
        }
        else
        {
            newVelocity.x = 0; // Stop horizontal movement if no input
        }

        // Jumping: Only if grounded
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newVelocity.y = JumpStrength; // Apply jump force
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newVelocity.y = -4 * JumpStrength; // Apply jump force
        }

        // Apply the combined velocity
        myRigidbody.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character collides with a specific GameObject (e.g., "Lava")
        if (collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Collided with Lava! Destroying character...");
            Destroy(gameObject); // Destroy this GameObject
        }
    }
}