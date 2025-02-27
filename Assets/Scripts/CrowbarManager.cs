using TMPro;
using UnityEngine;

public class CrowbarManager : MonoBehaviour
{
    public static CrowbarManager instance;
    public TextMeshProUGUI crowbarStatusText;
    private bool hasCrowbar = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCrowbar()
    {
        hasCrowbar = true;
        UpdateCrowbarUI();
    }
    
    public void ConsumeCrowbar()
    {
        hasCrowbar = false;
        UpdateCrowbarUI();
    }
    
    public bool HasCrowbar()
    {
        return hasCrowbar;
    }
    
    void UpdateCrowbarUI()
    {
        if (crowbarStatusText != null)
        {
            crowbarStatusText.text = "Crowbar: " + (hasCrowbar ? "Acquired" : "None");
        }
    }
}