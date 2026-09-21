using System;
using System.Collections;
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

    private Transform cat;
    private bool ratDie = false;
    private bool despawn = false;

    void Start()
    {
        transform.localScale = Vector2.zero;

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
        // Rat Spawn In
        if (transform.localScale.x < 7)
        {
            transform.localScale = new Vector2(Mathf.SmoothStep(transform.localScale.x, 7, 0.125F), Mathf.SmoothStep(transform.localScale.y, 7, 0.125F));
        }

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

        // Rat Die
        if (ratDie == true)
        {
            transform.position = new Vector2(Mathf.SmoothDamp(transform.position.x, transform.position.x + (Math.Sign(transform.position.x - cat.position.x) * 5.50F), ref moveSpeed, 0.125F), Mathf.SmoothDamp(transform.position.y, transform.position.y + (Math.Sign(transform.position.y - cat.position.y) * 5.50F), ref moveSpeed, 0.125F));

            if (despawn == true)
            {
                transform.localScale = new Vector2(Mathf.SmoothStep(transform.localScale.x, -7, 0.125F), Mathf.SmoothStep(transform.localScale.y, -7, 0.125F));
            }
        }
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
        roamDirection = UnityEngine.Random.insideUnitCircle.normalized;
        roamTimer = roamChangeTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cat")
        {
            GM.points += Assignedpoints;


            GM.UpdateScoreText();
            GM.numberofrats--;

            cat = collision.otherCollider.transform;
            ratDie = true;
            StartCoroutine(KillRatCountdown());
        }
    }

    IEnumerator KillRatCountdown()
    {
        yield return new WaitForSeconds(2F);

        despawn = true;

        yield return new WaitForSeconds(2F);

        Destroy(gameObject);
    }
}