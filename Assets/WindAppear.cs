using UnityEngine;
using System.Collections;

public class WindAppear : MonoBehaviour
{
    public float period = 2.0f;
    public bool active = true;
    public GameObject wind;

    void Start()
    {
        wind.SetActive(true);
        StartCoroutine(ToggleLaser());
    }

    
    IEnumerator ToggleLaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(period);
            active = !active;
            wind.SetActive(active);

        }
    }

}