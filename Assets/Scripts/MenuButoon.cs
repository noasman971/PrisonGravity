using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButoon : MonoBehaviour
{
    public GameObject playButton;
    public GameObject title;
    public GameObject settingsScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Cell");
    }

    public void Settings()
    {
        playButton.SetActive(false);
        title.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void exitSettings()
    {
        playButton.SetActive(true);
        title.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
