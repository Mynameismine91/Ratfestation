using UnityEngine;

public class Rat_Driver : MonoBehaviour
{
    public float Detection_range = 5f;
    public bool locked_in;
    public float moveSpeed = 2f;
    public Transform foodtransform;
    public float roamChangeTime = 2f;

    private Gamemanager GM;
    private Vector2 roamDirection;
    private float roamTimer;
    private int Assignedpoints;

    void Start()
    {
        ChooseRandomDirection();

        if (gameObject.name.StartsWith("slow"))
        {
            moveSpeed = 2f;
            Assignedpoints = 1;
        }
        else if (gameObject.name.StartsWith("fast"))
        {
            moveSpeed = 4f;
            Assignedpoints = 2;
        }
    }

    void Update()
    {
        // Find the closest food
        FindClosestFood();

        // Find GameManager
        if (GM == null)
        {
            GameObject gmObject = GameObject.Find("Gamemanager");

            if (gmObject != null)
            {
                GM = gmObject.GetComponent<Gamemanager>();
            }
        }

        // Check distance to closest food
        if (foodtransform != null)
        {
            float distance = Vector2.Distance(
                transform.position,
                foodtransform.position
            );

            if (distance <= Detection_range)
            {
                locked_in = true;
            }
            else
            {
                locked_in = false;
            }
        }
        else
        {
            // No food exists
            locked_in = false;
        }

        // Movement
        if (locked_in)
        {
            // Move toward closest food
            Vector2 direction =
                (foodtransform.position - transform.position).normalized;

            transform.Translate(
                direction * moveSpeed * Time.deltaTime
            );
        }
        else
        {
            // Random roaming
            roamTimer -= Time.deltaTime;

            if (roamTimer <= 0)
            {
                ChooseRandomDirection();
            }

            transform.Translate(
                roamDirection * moveSpeed * Time.deltaTime
            );
        }

        // Boundary
        Vector3 position = transform.position;

        position.y = Mathf.Clamp(position.y, -30.5f, 30f);
        position.x = Mathf.Clamp(position.x, -30.5f, 30f);

        transform.position = position;
    }

    void FindClosestFood()
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

        float closestDistance = Mathf.Infinity;
        GameObject closestFood = null;

        foreach (GameObject food in foods)
        {
            float distance = Vector2.Distance(
                transform.position,
                food.transform.position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFood = food;
            }
        }

        if (closestFood != null)
        {
            foodtransform = closestFood.transform;
        }
        else
        {
            foodtransform = null;
        }
    }

    void ChooseRandomDirection()
    {
        roamDirection = Random.insideUnitCircle.normalized;
        roamTimer = roamChangeTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cat")
        {
            GM.points += Assignedpoints;


            GM.UpdateScoreText();
            GM.numberofrats--;

            Destroy(gameObject);
        }
    }
}