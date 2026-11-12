
using UnityEngine;
using System.Collections;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float spawnRangeX = 12f;
    public float spawnRangeZ = 12f;
    public float respawnDelay = 2f;

    public void SpawnCollectible()
    {
        Vector3 spawnPosition;
        int attempts = 0;
        bool validPosition = false;

        do
        {
            spawnPosition = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                0.5f,
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );

            Collider[] hits = Physics.OverlapSphere(spawnPosition, 1.5f);
            validPosition = true;

            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Obstacle") || hit.CompareTag("Player"))
                {
                    validPosition = false;
                    break;
                }
            }

            attempts++;

        } while (!validPosition && attempts < 100);

        if (validPosition)
        {
            Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        }
    }

    public IEnumerator RespawnCollectible()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnCollectible();
    }
}
