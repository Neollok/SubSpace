using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    //Basicly copied from a tutorial. Don't know exactly how it works, but I can modify it if necessary

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D rb;
    private bool upsideDown;
    private bool doubleJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        upsideDown = GetComponent<PlayerMovement>().uDown;      //Grabs two boolian variables from player script
        doubleJump = GetComponent<PlayerMovement>().dJump;
    
        if (rb.velocity.y < 0)      //If player elevates
        {
            if (!upsideDown)
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            else
                rb.velocity -= Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
                                        //When jump button is released (dragged to ground faster probably)
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump") && !doubleJump) 
        {
            if (!upsideDown)
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

            else
                rb.velocity -= Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}