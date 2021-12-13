using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float sideWaysSpeed = 4;
    public float jumpSpeed = 10;

    public bool isGrounded = true;

    public bool isGoingUp = false;
    private float maxY = 7f;
    float minY = 2.67f;
    public bool isGoingDown = true;
    public static int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
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
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;
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
}
