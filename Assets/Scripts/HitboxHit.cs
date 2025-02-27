using UnityEngine;

public class HitboxHit : MonoBehaviour
{
    public GameObject Gamemanager;
    public SceneController sceneController;

    void Start()
    {
        Gamemanager = GameObject.Find("GameManager");
        sceneController = Gamemanager.GetComponent<SceneController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sceneController.RestartLevelDeath();
        }
    }
}
