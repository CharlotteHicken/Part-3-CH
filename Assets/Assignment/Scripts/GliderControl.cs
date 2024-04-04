using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GliderControl : PlayerControls
{

    public float slowGravity = 0.5f;
    public float defaultGravity;
    public bool canDoubleJump = true;
    public float doubleJumpPower = 50;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        jumppower = 10; //set jump power to lower so it doesn't jump too high
        defaultGravity = rb.gravityScale; //store the original gravity value to use later
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) //if space is pressed and on ground, set can double jump to true
        {
            canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && canDoubleJump) //if space is pressed, player is not on ground, and player can double jump
        {
            Jump(doubleJumpPower); //call the jump function with the doubleJumpPower value
            canDoubleJump = false; //set doublejump to false so it does not infinitely jump
        }

        if (Input.GetKey(KeyCode.Space) && !isOnGround) //when space is pressed and the player is not on the ground, set gravity to lower
        {
            rb.gravityScale = slowGravity;
        }
        else
        {
            rb.gravityScale = defaultGravity; //reset gravity to default
        }
    }

    protected void Jump(float jumpPower)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }
}
