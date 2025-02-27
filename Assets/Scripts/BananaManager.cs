using TMPro;
using UnityEngine;

public class BananaManager : MonoBehaviour
{
    public static BananaManager instance;
    public TextMeshProUGUI bananaCountText;
    private int bananas = 0;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddBanana()
    {
        bananas++;
        UpdateBananaUI();
    }
    
    public void UseBanana()
    {
        bananas = Mathf.Max(bananas - 1, 0);
        UpdateBananaUI();
    }
    
    public int GetBananaCount()
    {
        return bananas;
    }
    
    void UpdateBananaUI()
    {
        if (bananaCountText != null)
        {
            bananaCountText.text = "Bananas: " + bananas.ToString();
        }
    }
}