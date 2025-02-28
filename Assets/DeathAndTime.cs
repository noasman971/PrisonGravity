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
        
        displayText.text = "Death: " + nbrDeath.ToString() + " Time: " + FormatTime(seconds);
    }
    
    string FormatTime(int totalSeconds)
    {
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        string formattedTime = "";

        if (hours > 0)
            formattedTime += hours + "h ";
        if (minutes > 0 || hours > 0) 
            formattedTime += minutes + "m ";
        if (seconds > 0 || formattedTime == "") 
            formattedTime += seconds + "s";

        return formattedTime.Trim(); 
    }

}