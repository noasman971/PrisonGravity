using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal; 

public class LaserController : MonoBehaviour
{
    [SerializeField] private float toggleInterval = 3f;
    [SerializeField] private Light2D laserLight; 
    private SpriteRenderer spriteRenderer;
    private Collider2D laserCollider;
    private bool isLaserOn = true;
    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        laserCollider = GetComponent<Collider2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("musics/explosion");
        StartCoroutine(ToggleLaser());
    }

    IEnumerator ToggleLaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);
            isLaserOn = !isLaserOn;
            spriteRenderer.enabled = isLaserOn;
            laserCollider.enabled = isLaserOn;
            if(laserLight != null)
            {
                laserLight.enabled = isLaserOn;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isLaserOn)
        {
            audioSource.Play();
            Destroy(other.gameObject);
        }
    }
}