using System.Collections;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    public GameObject food;
    public float spawnRate;
    public Vector2 spawnArea;
    public int MaxCheese = 10;
    private Gamemanager GM;
    void Start()
    {
        StartCoroutine(FoodSpawner(spawnRate));
    }


    IEnumerator FoodSpawner(float waitTime)
    {
        while (true)
        {
            Vector2 random = new Vector2(Random.Range(-21, 30), Random.Range(-28, 22));
            yield return new WaitForSeconds(waitTime);

            Instantiate(food, random, Quaternion.identity);
        }
    }
}
