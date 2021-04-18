using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrackScript : MonoBehaviour
{
    // Variables
    [SerializeField] int stayAmount = 1;
    Vector3 ballPos;
    float cameraz;
    GameObject ball;
    Vector3 origpos;

    // Instantiate
    void Start()
    {
        ball = GameObject.Find("Ball");
        cameraz = transform.position.z;
        origpos = transform.position;
    }

    // Track the ball's position with the game camera!
    void Update()
    {
        ballPos = new Vector3(ball.transform.position.x, ball.transform.position.y, cameraz);
        transform.position = origpos - ((origpos-ballPos) / stayAmount);
    }
}
