using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;
using System.Text;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public bool isGameActive;

    public Player playerManager;
    public TextMeshProUGUI playerEmailText;
    
    public TextMeshProUGUI barrelsText;
    public TextMeshProUGUI ballsText;
    public TextMeshProUGUI pizzaText;
    public TextMeshProUGUI cookiesText;
    public TextMeshProUGUI skullsText;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<Player>();

        playerEmailText.text = playerManager.Email;
        
        barrelsText.text = "0";
        ballsText.text = "0";
        pizzaText.text = "0";
        cookiesText.text = "0";
        skullsText.text = "0";
        scoreText.text = "0";
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = UnityEngine.Random.Range(0, 4);
            Instantiate(targets[randomIndex]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
