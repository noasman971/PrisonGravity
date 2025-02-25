using UnityEngine;

public class CameraTr: MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.1f;

    private Vector3 initialPosition;
    private float shakeTimeRemaining = 0f;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeTimeRemaining -= Time.deltaTime;
        }
        else
        {
            transform.position = initialPosition;
        }
    }


    public void TriggerShake()
    {
        shakeTimeRemaining = shakeDuration;
    }
}
