using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;                  // Drag your Coin prefab here
    public float spawnInterval = 3f;         // Seconds between spawns
    public Vector2 spawnAreaMin;             // Bottom-left corner of spawn area
    public Vector2 spawnAreaMax;             // Top-right corner of spawn area

    void Start()
    {
        // Start spawning coins repeatedly
        InvokeRepeating("SpawnCoin", 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        // Choose a random position within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPos = new Vector2(x, y);

        // Create a coin at that position
        Instantiate(coin, spawnPos, Quaternion.identity);
    }
}