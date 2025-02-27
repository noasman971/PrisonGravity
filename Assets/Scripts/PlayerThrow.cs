using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject bananaPrefab;
    public float throwForce = 20f;

    void Update()
    {
        if (bananaPrefab != null && BananaManager.instance != null)
        {
            if (Input.GetButtonDown("Fire1") && BananaManager.instance.GetBananaCount() > 0)
            {
                ThrowBanana();
                BananaManager.instance.UseBanana();
            }
        }
  
    }

    void ThrowBanana()
    {
        Vector2 throwDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject banana = Instantiate(bananaPrefab, transform.position, Quaternion.identity);
        BananaProjectile projectile = banana.GetComponent<BananaProjectile>();
        projectile.direction = throwDirection;
    }
}