using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public int keysRequired = 3;
    public string sceneToLoad = "Couloir"; // Set the default scene name here
    private bool isOpen = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (KeyManager.instance.GetKeyCount() >= keysRequired)
            {
                OpenDoor();
            }
            else
            {
                Debug.Log("You need " + keysRequired + " keys to open this door. You have " + KeyManager.instance.GetKeyCount());
            }
        }
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Door is opening!");
            KeyManager.instance.RemoveKeys(keysRequired);
            Destroy(gameObject);
            SceneManager.LoadScene(sceneToLoad); // Load the scene based on the value set in the Inspector
        }
    }
}

