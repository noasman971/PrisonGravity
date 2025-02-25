using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    private bool gameOver = false;

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
