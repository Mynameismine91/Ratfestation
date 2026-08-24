using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    public GameObject food;
    public float spawnRate;
    public Vector2 spawnArea;
    void Start()
    {
        StartCoroutine(FoodSpawner(spawnRate));
    }

    IEnumerator FoodSpawner(float waitTime)
    {
        while (true)
        {
            Debug.Log("We are the Mouselings!! Please feed us!!");

            Vector2 random = new Vector2(Random.Range(-spawnArea.x, spawnArea.x + 1F), Random.Range(-spawnArea.y, spawnArea.y + 1));
            yield return new WaitForSeconds(waitTime);

            Instantiate(food, random, Quaternion.identity);
        }
        
    }
}
