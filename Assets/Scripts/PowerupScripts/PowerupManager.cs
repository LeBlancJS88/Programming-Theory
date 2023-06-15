using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerupPrefabs; // Encapsulation: Private field with serialized attribute for controlled access, representing an array of powerup prefabs
    [SerializeField] private float minSpawnTime = 30f; // Encapsulation: Private field with serialized attribute for controlled access, representing the minimum spawn time
    [SerializeField] private float maxSpawnTime = 45f; // Encapsulation: Private field with serialized attribute for controlled access, representing the maximum spawn time

    private BoxCollider spawnArea; // Encapsulation: Private field representing the spawn area

    private void Start()
    {
        spawnArea = GetComponent<BoxCollider>(); // Abstraction: Getting the BoxCollider component from the current GameObject
        StartPowerupSpawning();
    }

    private void StartPowerupSpawning()
    {
        // Schedule the first powerup spawn
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnPowerup), spawnTime); // Abstraction: Invoking the SpawnPowerup method after a random spawn time
    }

    private void SpawnPowerup()
    {
        // Randomly select a powerup prefab from the array
        int randomIndex = Random.Range(0, powerupPrefabs.Length);
        GameObject powerupPrefab = powerupPrefabs[randomIndex];

        // Calculate a random position within the spawn area
        Vector3 spawnPosition = GetRandomSpawnPosition(); // Abstraction: Calling the GetRandomSpawnPosition method to obtain a random spawn position

        // Instantiate the powerup object
        GameObject powerup = Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);

        // Attach Powerup script to the spawned powerup
        Powerup powerupComponent = powerup.GetComponent<Powerup>(); // Abstraction: Getting the Powerup component from the spawned powerup
        if (powerupComponent != null)
        {
            Debug.Log("Powerup spawned: " + powerupComponent.GetType().Name); // Abstraction: Logging the type of the spawned powerup
        }

        // Destroy the powerup after 5 seconds if it's not collected/destroyed
        Destroy(powerup, 5f);

        // Schedule the next powerup spawn
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnPowerup), spawnTime); // Abstraction: Invoking the SpawnPowerup method after a random spawn time
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 bounds = spawnArea.size; // Abstraction: Getting the size of the spawn area
        Vector3 center = spawnArea.center; // Abstraction: Getting the center position of the spawn area

        float randomX = Random.Range(-bounds.x / 2f, bounds.x / 2f);
        float randomY = Random.Range(-bounds.y / 2f, bounds.y / 2f);
        float randomZ = Random.Range(-bounds.z / 2f, bounds.z / 2f);

        return center + new Vector3(randomX, randomY, randomZ); // Abstraction: Returning a random position within the spawn area
    }
}