using System.Collections;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    // Reference to your Zombie prefab
    public GameObject zombiePrefab;

    // Where to spawn it
    public Transform zombieSpawnPoint;

    // How many zombies can ever be spawned total
    public int totalZombieAmt = 260;

    // Keep track of how many zombies we've spawned so far
    private int totalZombiesSpawned = 0;

    // A STATIC counter for how many zombies have been destroyed
    public static int totalZombiesDestroyed = 0;

    // Wave index used to calculate how many zombies to spawn each wave
    private int waveIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        // Keep spawning waves until we've reached totalZombieAmt
        while (totalZombiesSpawned < totalZombieAmt)
        {
            // Determine how many zombies this wave will spawn (1, 2, 4, 8, ...)
            int waveZombies = (int)Mathf.Pow(2, waveIndex);

            // Don't exceed the total limit
            if (totalZombiesSpawned + waveZombies > totalZombieAmt)
            {
                waveZombies = totalZombieAmt - totalZombiesSpawned;
            }

            // If waveZombies is 0, we're done
            if (waveZombies <= 0)
                break;

            // Remember how many zombies have been destroyed so far
            int destroyedCountAtWaveStart = totalZombiesDestroyed;

            // Spawn the zombies for this wave
            for (int i = 0; i < waveZombies; i++)
            {
                Instantiate(zombiePrefab, zombieSpawnPoint.position, zombieSpawnPoint.rotation);
                totalZombiesSpawned++;
            }

            // Now wait until all zombies from this wave are destroyed
            // That means 'totalZombiesDestroyed' must increase by 'waveZombies'
            int targetDestroyCount = destroyedCountAtWaveStart + waveZombies;

            // Wait until totalZombiesDestroyed >= targetDestroyCount
            while (totalZombiesDestroyed < targetDestroyCount)
            {
                yield return null; 
            }

            // Once the loop ends, it means this entire wave is destroyed
            // Move on to the next wave
            waveIndex++;
        }

        Debug.Log("All waves complete. Total zombies spawned: " + totalZombiesSpawned);
    }
}
