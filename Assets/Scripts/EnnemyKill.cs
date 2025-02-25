using UnityEngine;

public class EnnemyKill : MonoBehaviour
{
    public GameObject parent;
    private WolfAttack wolfAttackScript;
    public float jumpForce = 10f; 


    void Awake()
    {
        wolfAttackScript = parent.gameObject.GetComponent<WolfAttack>();
    }
    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = colision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Réinitialiser la vitesse verticale
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Appliquer la force
            }
            wolfAttackScript.gethit = true;
        }
    }
}
