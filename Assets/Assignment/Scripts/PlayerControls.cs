using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float speed;
    protected float movement;
    protected bool jumping;
    protected bool isOnGround = true;
    protected float jumppower;
    public static int sceneNumber;
    int maxSceneNumber = 3;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 200;
        jumppower = 30;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        movement = Input.GetAxis("Horizontal"); //set movement based on A D or arrow key input

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) //if space is pressed and the player is on the ground, jump and set player to not on the ground
        {
            jumping = true;
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //when escape is pressed, call the reset scene function with the value of the current scene
        {
            resetScene(sceneNumber);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * speed * Time.deltaTime, rb.velocity.y); //set the player's horizontal velocity based on the input, speed and time.deltatime. Keep the current vertical velocity

        if (jumping) //when the player is jumping
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower); //set veolicty to current horizontal velocity, but change the y velocity based on the jumppower
            jumping = false; //set jumping to false so player doesn't keep jumping
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) //if player collides with the ground, set isOnGround to true so player can jump again
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal")) //if player enters the goal zone, start the scene change coroutine
        {
            StartCoroutine(sceneChange());
        }
    }

    protected IEnumerator sceneChange()
    {
        speed = 0; //set player speed and jump to 0 so player cdoesn't leave the end zone
        jumppower = 0;
        yield return null;
        sceneNumber = (sceneNumber + 1) % maxSceneNumber; //increase the scene number, but go back to 0 if it tries to go to scene 4
        SceneManager.LoadScene(sceneNumber); //load the next scene based on this number
    }

    static void resetScene(int currentSceneNumber)
    {
        SceneManager.LoadScene(currentSceneNumber); //load the scene based on this number
    }

}
