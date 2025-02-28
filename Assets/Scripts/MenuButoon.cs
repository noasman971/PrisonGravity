using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject playButton;
    public GameObject title;
    public GameObject settingsScreen;
    public GameObject CreditsButton;
    public Button hardModeButton;
    public TMP_Text hardModeButtonText;
    void Start()
    {
        UpdateHardModeButton();
    }

    public void Play()
    {
        SceneManager.LoadScene("Cell");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Settings()
    {
        playButton.SetActive(false);
        title.SetActive(false);
        CreditsButton.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void exitSettings()
    {
        playButton.SetActive(true);
        title.SetActive(true);
        CreditsButton.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToggleHardMode()
    {
        GameOverManager.isHardMode = !GameOverManager.isHardMode;
        UpdateHardModeButton();
        Debug.Log("Hard mode activated: " + GameOverManager.isHardMode);
    }

    void UpdateHardModeButton()
    {
        if (GameOverManager.isHardMode)
        {
            hardModeButtonText.text = "Hard Mode: ON";
            hardModeButton.image.color = Color.red;
        }
        else
        {
            hardModeButtonText.text = "Hard Mode: OFF";
            hardModeButton.image.color = Color.white;
        }
    }
}