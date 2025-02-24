using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;
    public TextMeshProUGUI keyCountText;
    private int keys = 0;
    
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

    public void AddKey()
    {
        keys++;
        UpdateKeyUI();
    }
    
    void UpdateKeyUI()
    {
        keyCountText.text = "Keys: " + keys.ToString();
    }
}
