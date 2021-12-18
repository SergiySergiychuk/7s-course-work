using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -14.5f;
    public static float rightSide = -5.5f;
    public float intetnalLeft;
    public float internalRight;

    void Update()
    {
        if ((Player.position.x < leftSide || Player.position.x > rightSide) && Player.moveSpeed != 0)
        {
            FindObjectOfType<GameManager>().EndGame();
            Debug.Log("Dead at x=" + Player.position.x);
        }
    }
}
