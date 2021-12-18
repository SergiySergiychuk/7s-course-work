using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            coinFX.Play();
            this.gameObject.SetActive(false);
            GameManager.coinsCount += 1;
        }
    }
}
