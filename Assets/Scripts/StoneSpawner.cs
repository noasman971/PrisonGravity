using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public GameObject stonePrefab;     
    public int stoneCount = 5;           
    public float spawnAreaWidth = 10f;   
    public float spawnHeight = 10f;      

    public void SpawnStones()
    {
        Vector3 camPos = Camera.main.transform.position;
        for (int i = 0; i < stoneCount; i++)
        {
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            Vector3 spawnPos = new Vector3(camPos.x + randomX, camPos.y + spawnHeight, 0);
            Instantiate(stonePrefab, spawnPos, Quaternion.identity);
        }
    }
}