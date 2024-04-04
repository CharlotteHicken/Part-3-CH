using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerScript : PlayerControls
{
    public float flyforce;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        movement = Input.GetAxis("Horizontal"); //set movement based on A D or arrow key input

        if (Input.GetKeyDown(KeyCode.Space)) //if space is pressed, does not care about isOnground
        {
            isOnGround = false;
            //Debug.Log("space pressed");
            StartFlyRoutine(); //start fly function
        }
    }

    public void StartFlyRoutine()
    {
        StartCoroutine(FlyCoroutine()); //fly function then starts the coroutine
    }

    protected IEnumerator FlyCoroutine()
    {
        //Debug.Log("coroutine start");
        while (Input.GetKey(KeyCode.Space)) //while space is held down
        {
            rb.velocity = new Vector2(rb.velocity.x, flyforce); //move the player up based on the flyforce, keep the horizontal velocity based on 
            yield return null;
        }

        StopFlying(); //if space is not pressed, stop flying function becomes active
    }

    public void StopFlying()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); //set vertical velocity to 0
    }
}
