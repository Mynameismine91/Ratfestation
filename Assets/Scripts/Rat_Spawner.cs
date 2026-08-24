using UnityEngine;

public class Rat_Spawner : MonoBehaviour
{

    public GameObject[] ratPrefabs;

    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRat), 1f, spawnInterval);
    }

    void SpawnRat()
    {
        // Make sure we actually have rats to spawn
        if (ratPrefabs.Length == 0)
        {
            return;
        }

        // Pick a random rat
        int randomRat = Random.Range(0, ratPrefabs.Length);

        // Spawn the rat at the spawner's position
        Instantiate(
            ratPrefabs[randomRat],
            transform.position,
            Quaternion.identity
        );
    }
}

