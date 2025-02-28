using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    public GameObject canvaStats;
    private DeathAndTime deathAndTime;

    void Start()
    {
        deathAndTime = canvaStats.GetComponent<DeathAndTime>();
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
        
    }

    public void ReloadLevel()
    {            

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void RestartLevelDeath()
    {
        deathAndTime.nbrDeath += 1;
        PlayerPrefs.SetInt("nbrDeath", deathAndTime.nbrDeath);
        PlayerPrefs.Save(); 

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    }

    IEnumerator LoadLevel(int level)
    {
       transitionAnim.SetTrigger("End");
    yield return new WaitForSecondsRealtime(2.5f); 
    SceneManager.LoadSceneAsync(level);
    transitionAnim.SetTrigger("Start");
    
    }

}