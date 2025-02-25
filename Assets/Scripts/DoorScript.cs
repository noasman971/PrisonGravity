using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int keysRequired = 3;
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
        }
    }
}
