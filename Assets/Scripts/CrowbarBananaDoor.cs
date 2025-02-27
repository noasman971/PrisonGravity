using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowbarBananaDoor : MonoBehaviour
{
    public int bananasRequired = 1;
    public string sceneToLoad = "Couloir";
    private bool isOpen = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currentBananas = BananaManager.instance.GetBananaCount();
            bool hasCrowbar = CrowbarManager.instance.HasCrowbar();
            
            if (currentBananas >= bananasRequired && hasCrowbar)
            {
                OpenDoor();
            }
            else
            {
                Debug.Log($"You need {bananasRequired} banana(s) and a crowbar to open this door. You have {currentBananas} banana(s) and {(hasCrowbar ? "a crowbar" : "no crowbar")}.");
            }
        }
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Door is opening!");
            Destroy(gameObject);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}