using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float moveSpeed;
    public float sideWaysSpeed = 4;
    public float jumpSpeed = 10;
    public bool isGrounded = true;

    public bool isGoingUp = false;
    private float maxY = 7f;
    float minY = 2.67f;
    public bool isGoingDown = true;
    public static int frameCount = 0;

    public static Vector3 position;

    void Start()
    {
        moveSpeed = 7;
    }

    void Update()
    {
        position = transform.position;
        if (frameCount % 300 == 0)
        {
            moveSpeed += 1;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        Jump();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideWaysSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideWaysSpeed * -1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGoingUp = true;
        }
        frameCount += 1;
    }

    void Jump()
    {
        float x = position.x;
        float y = position.y;
        float z = position.z;
        if (isGoingUp && y < maxY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
        } else if ((isGoingUp && y >= maxY) || (isGoingDown && y > minY))
        {
            isGoingUp = false;
            isGoingDown = true;
            transform.Translate(Vector3.down * Time.deltaTime * jumpSpeed);
        } else if (isGoingDown && y <= minY)
        {
            transform.position = new Vector3(x, minY, z);
            isGoingDown = false;
            isGoingUp = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
