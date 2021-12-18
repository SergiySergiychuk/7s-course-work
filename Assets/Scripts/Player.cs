using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VerticalState
{
    Idle,
    GoingUp,
    GoingDown
}
public class Player : MonoBehaviour
{
    public static float moveSpeed;
    public float sideWaysSpeed = 4;
    public float jumpSpeed = 10;

    public VerticalState verticalState = VerticalState.Idle;
    private float maxY = 7f;
    float minY = 2.67f;

    public static Vector3 position;

    void Start()
    {
    }

    void Update()
    {
        position = transform.position;
        if (position.z % 20 == 0)
        {
            moveSpeed += 1;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        HandleJump();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideWaysSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideWaysSpeed * -1);
        }
        if (Input.GetKeyDown(KeyCode.Space) && verticalState == VerticalState.Idle)
        {
            verticalState = VerticalState.GoingUp;
        }
    }

    void HandleJump()
    {
        float x = position.x;
        float y = position.y;
        float z = position.z;
        if (verticalState == VerticalState.GoingUp && y < maxY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
        }
        else if (
            (verticalState == VerticalState.GoingUp && y >= maxY) ||
            (verticalState == VerticalState.GoingDown && y > minY))
        {
            verticalState = VerticalState.GoingDown;
            transform.Translate(Vector3.down * Time.deltaTime * jumpSpeed);
        }
        else if (verticalState == VerticalState.GoingDown && y <= minY)
        {
            transform.position = new Vector3(x, minY, z);
            verticalState = VerticalState.Idle;
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
