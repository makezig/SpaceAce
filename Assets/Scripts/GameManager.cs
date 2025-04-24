using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Score = 0;
    public bool gameOver = false;
    public GameOverScreen gameOverScreen;

    private AudioSource audioSource;
    private AudioSource explosion; // This is your SFX AudioSource

    public AudioClip explosionSFX; // <-- THIS is the actual AudioClip
    public AudioClip laserSFX; // drag in another AudioClip via Inspector
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        explosion = gameObject.AddComponent<AudioSource>();
        explosion.playOnAwake = false;

        Debug.Log("GUGUGAGA");
        gameOver = false;
    }

    void Awake()
    {
        
        // Singleton pattern to make sure there's only one GameManager
        if (Instance == null)
        {
            Instance = this;
            
            SceneManager.sceneLoaded += OnSceneLoaded; // Hook up scene loaded callback
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Try to find GameOverScreen again when scene loads
        if (gameOverScreen == null)
        {
            gameOverScreen = GameObject.Find("BackGround")?.GetComponent<GameOverScreen>();
        }

        // If game was already over, show the screen again
        if (gameOver && gameOverScreen != null)
        {
            gameOverScreen.SetUp(Score);
        }
    }

    public void AddPoints(int points)
    {
        Score += points;
        
        Debug.Log("Score: " + Score);

        if (explosionSFX != null)
        {
            explosion.pitch = Random.Range(0.8f, 1.0f); // Slight random pitch variation
            explosion.PlayOneShot(explosionSFX, 0.6f); // 0.5 = 50% volume
            
            explosion.PlayOneShot(laserSFX, 0.7f); // different clip, different volume
        }
    }
    public void SetGameOver(bool state)
    {
        gameOver = state;
        Debug.Log("Game Over triggered: " + gameOver);

        if (gameOverScreen == null)
        {
            gameOverScreen = GameObject.Find("BackGround")?.GetComponent<GameOverScreen>();
        }

        if (gameOverScreen != null)
        {
            gameOverScreen.SetUp(Score);
        }
        else
        {
            Debug.LogWarning("GameOverScreen not found in scene.");
        }
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}

