using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public GameObject gameOverPanel; 
    private bool gameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null && !gameOver)
        {
            GameOver();
        }

        if (gameOver && Input.GetMouseButtonDown(0))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);
    }
}