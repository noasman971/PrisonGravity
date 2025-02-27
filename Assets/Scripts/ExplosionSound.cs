using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    public AudioClip explosion;
    public AudioSource audioSource;
    void StartSound()
    {
        audioSource.clip = explosion;
        audioSource.Play();
    }
    
}
