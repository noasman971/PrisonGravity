using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float toggleInterval = 3f;
    [SerializeField] private Light2D laserLight; 
    private SpriteRenderer spriteRenderer;
    private Collider2D laserCollider;
    private bool isLaserOn = true;
    private AudioSource audioSource;
    private GameObject GameManager;
    private SceneController sceneController;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        sceneController = GameManager.GetComponent<SceneController>();
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
            sceneController.RestartLevelDeath();
        }
    }
}