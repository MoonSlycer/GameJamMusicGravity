using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the input direction
        Vector2 CurrentDirection = new Vector2(0f, 0f);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            CurrentDirection = new Vector2(-1, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CurrentDirection = new Vector2(1, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            CurrentDirection = new Vector2(0f, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            CurrentDirection = new Vector2(0f, -1);
        }

        // Apply it to movement
        if (CurrentDirection != -Physics2D.gravity.normalized) // make sure we can't fly off of the ground
        {
            rigidBody.AddForce(CurrentDirection * movementSpeed);
        }

    }
}
