using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public bool isGameActive { get; set; }
    public bool paused { get; set; }

    private float spawnRate = 0.5f;
    private int score = 0;
    private float lives;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        // ABSTRACTION
        StartGame(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ABSTRACTION
            PauseGame();
        }
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
    }

    // POLYMORPHISM
    public void UpdateLives(int newLives)
    {
        lives += newLives;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void UpdateLives(float newLives)
    {
        lives += newLives;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate *= difficulty;
        UpdateScore(0);
        UpdateLives(3);
        StartCoroutine(SpawnTargets());
    }

    public void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
