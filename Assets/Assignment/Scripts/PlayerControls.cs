using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float movement;
    bool jumping;
    public bool isOnGround = true;
    public float jumppower;
    public static int sceneNumber;
    int maxSceneNumber = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 200;
        jumppower = 30;
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jumping = true;
            isOnGround = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * speed * Time.deltaTime, rb.velocity.y);

        if (jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            StartCoroutine(sceneChange());
        }
    }

    IEnumerator sceneChange()
    {
        speed = 0;
        jumppower = 0;
        //sleep animation or coroutine that plays animation
        yield return null;
        sceneNumber = (sceneNumber + 1) % maxSceneNumber;
        SceneManager.LoadScene(sceneNumber);
    }

}
