using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowbarDestructible : MonoBehaviour
{
    public string sceneToLoad = "Couloir";
    private bool isDestroyed = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDestroyed)
        {
            if (CrowbarManager.instance.HasCrowbar())
            {
                BreakObject();
            }
            else
            {
                Debug.Log("You need a crowbar to break this!");
            }
        }
    }

    void BreakObject()
    {
        isDestroyed = true;
        Debug.Log("Object destroyed using crowbar!");
        CrowbarManager.instance.ConsumeCrowbar();
        Destroy(gameObject);
        SceneManager.LoadScene(sceneToLoad);
    }
}