using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowEndcanvas : MonoBehaviour
{
    public GameObject endcanvas;
    void Start()
    {
        GameObject endcanvas = GameObject.Find("EndCanvas");
        endcanvas.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        endcanvas.SetActive(true);
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        endcanvas.SetActive(false);
    }

    public void MenuButton()
    {
        PlayerPrefs.SetInt("nbrDeath", 0);
        PlayerPrefs.SetInt("seconds", 0);
        PlayerPrefs.Save(); 
        SceneManager.LoadScene("Menu");
    }
}