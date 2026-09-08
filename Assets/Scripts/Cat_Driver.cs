using UnityEngine;

public class Cat_Driver : MonoBehaviour
{
    [SerializeField] float catSpeed = 5f;
    [SerializeField] Transform obj;
    [SerializeField] Animator animator;

    private bool left = false;
    private bool right = false;
    private bool down = false;

    // Update is called once per frame
    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(x, y, 0);
        tempVect = tempVect.normalized * catSpeed * Time.deltaTime;

        obj.transform.position += tempVect;


        // Boundary
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -30f, 30f);
        position.x = Mathf.Clamp(position.x, -30f, 30f);
        transform.position = position;


        // Reset all directions first
        left = false;
        right = false;
        down = false;

        // Determine direction
        if (y < 0)
        {
            down = true;
        }
        else if (x < 0)
        {
            left = true;
        }
        else if (x > 0)
        {
            right = true;
        }


        // Send the bools to the Animator
        animator.SetBool("left", left);
        animator.SetBool("right", right);
        animator.SetBool("down", down);
    }
}