using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraFollow cameraFollow;  
    public StoneSpawner stoneSpawner;  
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            cameraFollow.ShakeCamera(shakeDuration, shakeMagnitude);
            stoneSpawner.SpawnStones();
        }
    }
}