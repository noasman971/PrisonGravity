using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float toggleInterval = 3f;
    private SpriteRenderer spriteRenderer;
    private Collider2D laserCollider;
    private bool isLaserOn = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        laserCollider = GetComponent<Collider2D>();
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
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isLaserOn)
        {
            Destroy(other.gameObject);
        }
    }
}
