using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Variables
    [SerializeField] MouseMove paddle;
    [SerializeField] AudioSource rebound;
    [SerializeField] AudioClip[] clips;
    [SerializeField] int randomness;
    [SerializeField] int yPush;

    Rigidbody2D rigidBody2D;

    bool isClicked = false;

    // Assigns Rigidbody2D because we're too lazy to set it in editor
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Ball launching at start of game
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isClicked)
        {
            rigidBody2D.velocity = new Vector2(0, yPush);
            isClicked = true;
        }
        if (!isClicked)
        {
            transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + 1f);
        }
    }

    // Random rebound on collision to prevent the ball from getting stuck on top of a block
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomness),
            Random.Range(0, randomness));

        rigidBody2D.velocity += velocityTweak;

        rebound.clip = clips[Random.Range(0,clips.Length-1)];
        rebound.Play();
    }
}
