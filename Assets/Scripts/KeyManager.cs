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
    
    public void RemoveKeys(int amount)
    {
        keys = Mathf.Max(keys - amount, 0);
        UpdateKeyUI();
    }
    
    public int GetKeyCount()
    {
        return keys;
    }
    
    void UpdateKeyUI()
    {
        keyCountText.text = "Keys: " + keys.ToString();
    }
}
