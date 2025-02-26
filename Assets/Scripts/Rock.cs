using UnityEngine;

public class Rock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag != "Rock")
        {
            Destroy(gameObject); 
        }
    }
}
