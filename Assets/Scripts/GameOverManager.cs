using UnityEngine;

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
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
