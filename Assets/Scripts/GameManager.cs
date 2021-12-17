using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    public static int coinsCount = 0;
    private bool gameHasEnded = false;
    public Text scoreText;
    public Text gameOverText;
    public Text coinsCountText;
    void Update()
    {
        scoreText.text = (Player.position.z + 23.41).ToString("0");
        coinsCountText.text = coinsCount.ToString();
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(-10, 0, zPos), Quaternion.identity);
        zPos += 49;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverText.text = "Game Over!";

            // TODO add death animation
            Player.moveSpeed = 0;
            Invoke("RestartGame", 2f);
        }
    }

    void RestartGame()
    {
        gameHasEnded = false;
        coinsCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
