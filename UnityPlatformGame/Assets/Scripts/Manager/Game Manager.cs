using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;
    private float respawnTimeStart;
    private bool respawn;

    private int respawnCount = 0;
    private const int maxRespawns = 3;

    private CinemachineVirtualCamera CVC;

    public GameObject pauseButton; // Reference to the Pause button
    public GameObject resumeButton; // Reference to the Resume button

    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script
    public KeyManager keyManager; // Reference to the KeyManager script

    [SerializeField]
    private GameObject gameOverScreen; // Reference to the game over screen UI
    [SerializeField] private Image[] lifeIcons; // Array of UI Image components representing lives

    public void Start()
    {
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        // Call the SpawnEnemies method from the EnemySpawner
        if (enemySpawner != null)
        {
            enemySpawner.SpawnEnemies();
        }
        else
        {
            Debug.LogError("EnemySpawner reference is missing!");
        }

        // Ensure gameOverScreen is assigned
        if (gameOverScreen == null)
        {
            Debug.LogError("GameOverScreen reference is missing!");
        }
        else
        {
            gameOverScreen.SetActive(false); // Hide game over screen at the start
        }

        // Hide all life icons initially
        foreach (Image lifeIcon in lifeIcons)
        {
            lifeIcon.gameObject.SetActive(false);
        }

        // Show initial lives
        UpdateLivesUI();

        // Ensure buttons are assigned
        if (pauseButton == null || resumeButton == null)
        {
            Debug.LogError("Pause or Resume button reference is missing!");
        }
        else
        {
            pauseButton.SetActive(true);  // Show the Pause button initially
            resumeButton.SetActive(false); // Hide the Resume button initially
        }
    }

    private void Update()
    {
        CheckRespawn();
    }

    public void Respawn()
    {
        if (respawnCount < maxRespawns)
        {
            respawnTimeStart = Time.time;
            respawn = true;
        }
        else
        {
            ShowGameOverScreen();
        }
    }

    private void CheckRespawn()
    {
        if (Time.time >= respawnTimeStart + respawnTime && respawn)
        {
            respawnCount++;
            var playerTemp = Instantiate(player, respawnPoint);
            CVC.m_Follow = playerTemp.transform;

            // Update KeyManager with the new player reference
            keyManager.UpdatePlayer(playerTemp);

            respawn = false;

            // Update lives UI
            UpdateLivesUI();

            if (respawnCount >= maxRespawns)
            {
                ShowGameOverScreen();
            }
        }
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f; // Freeze the game
        }
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f; // Unfreeze the game
        respawnCount = 0;

        // Reset the lives UI
        foreach (Image lifeIcon in lifeIcons)
        {
            lifeIcon.gameObject.SetActive(true); // Reset all hearts
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < maxRespawns - respawnCount)
            {
                lifeIcons[i].gameObject.SetActive(true); // Show remaining lives
            }
            else
            {
                lifeIcons[i].gameObject.SetActive(false); // Hide lost lives
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
