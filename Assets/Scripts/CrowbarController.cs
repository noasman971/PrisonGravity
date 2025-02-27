using UnityEngine;

public class CrowbarPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CrowbarManager.instance.CollectCrowbar();
            Destroy(gameObject);
        }
    }
}