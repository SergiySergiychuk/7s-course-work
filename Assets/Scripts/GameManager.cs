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
    public Text startCounterText;
    public static int frameCount = 0;
    void Start()
    {
        StartCoroutine(StartGame());
    }

    void Update()
    {
        scoreText.text = (Player.position.z + 23.41).ToString("0");
        coinsCountText.text = coinsCount.ToString();
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
        frameCount += 1;
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(-10, 0, zPos), Quaternion.identity);
        zPos += 49;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        startCounterText.text = "2";
        yield return new WaitForSeconds(1);
        startCounterText.text = "1";
        yield return new WaitForSeconds(1);
        startCounterText.text = "GO!";
        yield return new WaitForSeconds(1);
        startCounterText.text = "";
        Player.moveSpeed = 7;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverText.text = "Game Over!";

            // TODO add death animation
            Player.moveSpeed = 0;
            frameCount = 0;
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
