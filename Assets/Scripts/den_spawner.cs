using System.Collections;
using UnityEngine;

public class den_Spawner : MonoBehaviour
{
    public GameObject Den;
    public float spawnRate;
    public float spawnRateLimit;
    public float difficultyIncreaseRate;
    public float left;
    public float up;
    public float right;

    Vector2 dropPosition;
    GameObject spawnedObject;

    private void Start()
    {
        StartCoroutine(ObjectSpawn());
    }

    public IEnumerator ObjectSpawn()
    {
   

        dropPosition = new Vector2(Random.Range(left, right), up);

        spawnedObject = Instantiate(Den, dropPosition, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);

        spawnRate = Mathf.Clamp(
            spawnRate * difficultyIncreaseRate,
            spawnRateLimit,
            5F
        );

   
    }
}
