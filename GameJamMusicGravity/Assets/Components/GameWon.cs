using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{
    void Start()
    {
        GravitySwap.bDisabled = true;
        Physics2D.gravity = new Vector2(0f, 0f);
    }
}
