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
        movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOnGround = false;
            //Debug.Log("space pressed");
            StartFlyRoutine();
        }
    }

    public void StartFlyRoutine()
    {
        StartCoroutine(FlyCoroutine());
    }

    protected IEnumerator FlyCoroutine()
    {
        //Debug.Log("coroutine start");
        while (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, flyforce);
            yield return null;
        }

        StopFlying();
    }

    public void StopFlying()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
    }
}
