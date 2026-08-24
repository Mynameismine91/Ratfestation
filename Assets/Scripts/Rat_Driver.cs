using UnityEngine;



public class Rat_Driver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public float Detection_range = 5; // this is the range or distance the food is from the rat before they start going straight for it
public bool locked_in; //the state wherein the rats are going straight to the food
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
    if (foodtransform == null)
    {
        GameObject food = GameObject.FindGameObjectWithTag("Food");

        if (food != null)
        {
            foodtransform = food.transform;
        }
    }

if (GM == null)
    {
        GameObject gmObject = GameObject.Find("Gamemanager");

        if (gmObject != null)
        {
            GM = gmObject.GetComponent<Gamemanager>();
                    Debug.Log("1");

        }
    }

    // Check distance to food
    // If food exists, check its distance
    if (foodtransform != null)
    {
        float distance = Vector3.Distance(
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
        // Move directly toward food
        Vector2 direction = (foodtransform.position - transform.position).normalized;

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    else
    {
        // Random roaming
        roamTimer -= Time.deltaTime;

        if (roamTimer <= 0)
        {
            ChooseRandomDirection();
        }

        transform.Translate(roamDirection * moveSpeed * Time.deltaTime);
    }
        Vector3 position = transform.position;
    position.y = Mathf.Clamp(position.y, -30.5f, 30f);
    position.x = Mathf.Clamp(position.x, -30.5f, 30f);    
    transform.position = position;
}

void ChooseRandomDirection()
{
    roamDirection = Random.insideUnitCircle.normalized;
    roamTimer = roamChangeTime;
}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Cat" )
        {
            GM.points += Assignedpoints;
        Debug.Log("2");
        GM.UpdateScoreText();

            Destroy(gameObject);
        }
    }
}