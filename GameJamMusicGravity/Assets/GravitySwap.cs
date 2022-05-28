using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    public float gravitySize = 80f;
    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        Physics2D.gravity = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Gravity Swap", false);
        Vector2 CurrentDirection = Physics2D.gravity; //new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.A))
        {
            CurrentDirection = new Vector2(-gravitySize, 0f);
            animator.SetBool("Gravity Swap", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            CurrentDirection = new Vector2(gravitySize, 0f);
            animator.SetBool("Gravity Swap", true);
        }

        if (Input.GetKey(KeyCode.W))
        {
            CurrentDirection = new Vector2(0f, gravitySize);
            animator.SetBool("Gravity Swap", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            CurrentDirection = new Vector2(0f, -gravitySize);
            animator.SetBool("Gravity Swap", true);
        }

        Physics2D.gravity = CurrentDirection;
    }

}
