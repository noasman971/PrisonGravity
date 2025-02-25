using UnityEngine;

public class HitboxHit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("HitboxHit");
        }
    }
}
