using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z < Player.position.z - 250 && transform.position.z > 0)
        {
            Destroy(gameObject);
            Debug.Log("Object deleted at z=" + transform.position.z);
        }
    }
}