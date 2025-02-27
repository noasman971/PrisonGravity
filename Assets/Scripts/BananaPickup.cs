using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BananaManager.instance.AddBanana();
            Destroy(gameObject);
        }
    }
}