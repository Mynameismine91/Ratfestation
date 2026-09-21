using UnityEngine;

public class Food : MonoBehaviour
{
    private Gamemanager GM;
    public den_Spawner[] spawners;

    void Start()
    {
        // Find Gamemanager in the scene
        GameObject gmObject = GameObject.Find("Gamemanager");

        if (gmObject != null)
        {
            GM = gmObject.GetComponent<Gamemanager>();

            if (GM != null)
            {
                GM.CheeseOnDeck++;
            }
        }

        // Find all den_Spawner objects in the scene
        spawners = FindObjectsByType<den_Spawner>(FindObjectsSortMode.None);

        if (spawners.Length == 0)
        {
            Debug.LogError("Food could not find any den_Spawner objects!");
        }

        transform.localScale = Vector2.zero;
    }

    private void Update()
    {
        // Cheese Spawn In
        if (transform.localScale.x < 0.5F)
        {
            transform.localScale = new Vector2(Mathf.SmoothStep(transform.localScale.x, 0.5F, 0.125F), Mathf.SmoothStep(transform.localScale.y, 0.5F, 0.125F));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rat"))
        {
            // Prevent the food from triggering multiple times
            if (GM != null)
            {
                GM.points--;
                GM.UpdateScoreText();
                GM.CheeseOnDeck--;
            }

            // Pick one of the spawners
            if (spawners.Length > 0)
            {
                int randomIndex = Random.Range(0, spawners.Length);

                StartCoroutine(spawners[randomIndex].ObjectSpawn());
            }

            Destroy(gameObject, 3f);
        }
    }
}
