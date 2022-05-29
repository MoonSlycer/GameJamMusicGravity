using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    /** Fall speed of the world */
    public float gravitySize = 80f;
    /** Reference to the character's animator */
    public Animator characterAnimator;

    // Cached reference to the level's main camera
    private Animator cameraAnimator;



    void Awake()
    {
        cameraAnimator = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();

        Physics2D.gravity = new Vector2(0f, 0f);
    }

    void Update()
    {
        characterAnimator.SetBool("Gravity Swap", false);
        cameraAnimator.SetBool("Gravity Swap", false);
        Vector2 CurrentDirection = Physics2D.gravity; //new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.A))
        {
            CurrentDirection = new Vector2(-gravitySize, 0f);
            characterAnimator.SetBool("Gravity Swap", true);
            cameraAnimator.Play("Camera_Grav", 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            CurrentDirection = new Vector2(gravitySize, 0f);
            characterAnimator.SetBool("Gravity Swap", true);
            cameraAnimator.Play("Camera_Grav", 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            CurrentDirection = new Vector2(0f, gravitySize);
            characterAnimator.SetBool("Gravity Swap", true);
            cameraAnimator.Play("Camera_Grav", 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            CurrentDirection = new Vector2(0f, -gravitySize);
            characterAnimator.SetBool("Gravity Swap", true);
            cameraAnimator.Play("Camera_Grav", 0, 0);
        }

        Physics2D.gravity = CurrentDirection;
    }

}
