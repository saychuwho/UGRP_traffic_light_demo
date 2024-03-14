using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// simple script to move maincamera with keyboard
public class maincameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        float moveZ = 0f;

        float rotate = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY += 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY -= 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotate += 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotate -= 1f;
        }

        transform.Translate(new Vector3(moveX, moveY, moveZ)*0.1f);
        transform.Rotate(Vector3.up, -rotate);
    }
}
