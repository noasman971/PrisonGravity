using TMPro;
using UnityEngine;

public class DeathAndTime : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public int nbrDeath;
    private float timeElapsed;  
    private int seconds;

    void Start()
    {
        seconds = PlayerPrefs.GetInt("seconds", 0);
        timeElapsed = seconds; 
    }
    
    void Update() {
        nbrDeath = PlayerPrefs.GetInt("nbrDeath", 0);
        
        timeElapsed += Time.deltaTime;
        seconds = Mathf.FloorToInt(timeElapsed);
        
        PlayerPrefs.SetInt("seconds", seconds);
        PlayerPrefs.Save(); 
        
        displayText.text = "Death: " + nbrDeath.ToString() + " Time: " + seconds.ToString() + " seconds";
    }
}