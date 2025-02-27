using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButoon : MonoBehaviour
{
    public GameObject playButton;
    public GameObject CreditsButton;
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
    
    public void ToggleHardMode()
    {
        GameOverManager.isHardMode = !GameOverManager.isHardMode;
        Debug.Log("Hard mode activé : " + GameOverManager.isHardMode);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Settings()
    {
        playButton.SetActive(false);
        title.SetActive(false);
        settingsScreen.SetActive(true);
        CreditsButton.SetActive(false);
    }

    public void exitSettings()
    {
        playButton.SetActive(true);
        title.SetActive(true);
        settingsScreen.SetActive(false);
        CreditsButton.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
