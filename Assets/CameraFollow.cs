using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetX = 0f;
    public float smoothSpeed = 0.125f;

    private float fixedY;

    void Start()
    {

        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player != null)
        {

            Vector3 targetPosition = new Vector3(player.position.x + offsetX, fixedY, transform.position.z);


            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}
