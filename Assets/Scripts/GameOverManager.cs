using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
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
        isRestarting = false;
    }
    
    void Update()
    {
        if (!isRestarting && GameObject.FindGameObjectWithTag("Player") == null)
        {
            StartCoroutine(RestartGame());
        }
    }
    
    public IEnumerator RestartGame()
    {
        isRestarting = true;
        Time.timeScale = 1f;
    
        if (isHardMode)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Cell");
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