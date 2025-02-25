using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private bool pause = false;
    public GameObject pauseUI;

    

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    
    }
 
    public void Resume()
    {
        pause = false;
        //GameObject.Find("hero_7").GetComponent<Hero>().enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        //GameObject.Find("hero_7").GetComponent<Hero>().enabled = true;
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            pause = !pause;



            if (pause)
            {  //GameObject.Find("hero_7").GetComponent<Hero>().enabled = false;
                 pauseUI.SetActive(true);
                
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Resume();
            }
        }
    }

}
