using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    private GameObject gameOverPanel; 
    private bool gameOver = false;
    private bool isRestarting = false;
    public static bool isHardMode = false;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f;
        gameOver = false;
        isRestarting = false;
        
        StartCoroutine(SetupAfterSceneLoad());
    }
    
    IEnumerator SetupAfterSceneLoad()
    {
        yield return new WaitForEndOfFrame();
        
        gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameOverPanel not found in scene: " + SceneManager.GetActiveScene().name);
        }
    }
    
    void Update()
    {
        if (!gameOver && !isRestarting && GameObject.FindGameObjectWithTag("Player") == null)
        {
            TriggerGameOver();
        }
        
        if (gameOver && !isRestarting && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(RestartGame());
        }
    }
    
    public void TriggerGameOver()
    {
        gameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }
    
    public IEnumerator RestartGame()
    {
        isRestarting = true;
        Time.timeScale = 1f;
    
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    
        if (isHardMode)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");
            asyncLoad.allowSceneActivation = true;
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        else
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            asyncLoad.allowSceneActivation = true;
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
    
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}