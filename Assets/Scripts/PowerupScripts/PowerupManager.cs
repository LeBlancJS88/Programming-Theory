using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerupPrefabs;
    [SerializeField] private float minSpawnTime = 30f;
    [SerializeField] private float maxSpawnTime = 45f;

    private BoxCollider spawnArea;

    private void Start()
    {
        spawnArea = GetComponent<BoxCollider>();
        StartPowerupSpawning();
    }

    private void StartPowerupSpawning()
    {
        // Schedule the first powerup spawn
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnPowerup), spawnTime);
    }

    private void SpawnPowerup()
    {
        // Randomly select a powerup prefab from the array
        int randomIndex = Random.Range(0, powerupPrefabs.Length);
        GameObject powerupPrefab = powerupPrefabs[randomIndex];

        // Calculate a random position within the spawn area
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Instantiate the powerup object
        GameObject powerup = Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);

        // Attach Powerup script to the spawned powerup
        Powerup powerupComponent = powerup.GetComponent<Powerup>();
        if (powerupComponent != null)
        {
            Debug.Log("Powerup spawned: " + powerupComponent.GetType().Name);
        }

        // Destroy the powerup after 5 seconds if it's not collected/destroyed
        Destroy(powerup, 5f);

        // Schedule the next powerup spawn
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnPowerup), spawnTime);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 bounds = spawnArea.size;
        Vector3 center = spawnArea.center;

        float randomX = Random.Range(-bounds.x / 2f, bounds.x / 2f);
        float randomY = Random.Range(-bounds.y / 2f, bounds.y / 2f);
        float randomZ = Random.Range(-bounds.z / 2f, bounds.z / 2f);

        return center + new Vector3(randomX, randomY, randomZ);
    }
}