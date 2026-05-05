using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public CharacterStats playerStats;
    public Transform playerTransform;
    public GameObject shopPanel;

    private float startTime;
    private bool isGameOver = false;

    void Start()
    {
        startTime = Time.time;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (playerTransform.position.y < -20f && !isGameOver)
        {
            HandleGameOver();
        }

        if (Input.GetKeyDown(KeyCode.B)) // 'B' for Buy/Shop
        {
            bool isActive = shopPanel.activeSelf;
            shopPanel.SetActive(!isActive);

            Time.timeScale = isActive ? 1f : 0f;
            Cursor.lockState = isActive ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isActive;
        }
    }

    void OnEnable()
    {
        if (playerStats != null)
        {
            playerStats.OnDeath += HandleGameOver;
        }
    }

    void OnDisable()
    {
        if (playerStats != null)
        {
            playerStats.OnDeath -= HandleGameOver;
        }
    }

    void HandleGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        // 1. Calculate Score
        float timeSurvived = Time.time - startTime;
        scoreText.text = "Time Survived: " + timeSurvived.ToString("F1") + "s";

        // 2. Show UI and Pause Game
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pauses physics and movement
        Cursor.lockState = CursorLockMode.None; // Release mouse
        Cursor.visible = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}