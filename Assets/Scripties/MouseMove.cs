using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseMove : MonoBehaviour
{
    // Adjust this to make the paddle turn faster!!
    [SerializeField] int rotationScale;

    // Move the paddle and rotate it with user input!!
    void Update()
    {
        // Rotation
        float scrollDir = Input.GetAxis("Mouse ScrollWheel");
        transform.Rotate(0, 0, scrollDir * rotationScale);

        // Position
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,4,18);
        transform.position = PaddlePos;
    }
}
