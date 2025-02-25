using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothSpeed = 0.125f;
    private bool isShaking = false;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        if (!isShaking)
        {
            StartCoroutine(Shake(duration, magnitude));
        }
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        isShaking = true;
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            
            transform.position = originalPosition + new Vector3(x, y, 0);
            
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isShaking = false;
    }
}