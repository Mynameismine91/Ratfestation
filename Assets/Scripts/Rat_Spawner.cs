using UnityEngine;

public class Rat_Spawner : MonoBehaviour
{

    public GameObject[] ratPrefabs;
public Gamemanager Gm;
    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRat), 1f, spawnInterval);

                if (Gm == null)
        {
            GameObject gmObject = GameObject.Find("Gamemanager");

            if (gmObject != null)
            {
                Gm = gmObject.GetComponent<Gamemanager>();
                Debug.Log("GameManager found");
            }
        }
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

        Gm.numberofrats++;

    }
}

