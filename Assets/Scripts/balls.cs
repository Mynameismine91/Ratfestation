using UnityEngine;

public class balls : MonoBehaviour
{
 public Rigidbody2D rb;
     void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = Mathf.Clamp(position.x, -30f, 30f);
        position.y = Mathf.Clamp(position.y, -30f, 30f);
        rb.position = position;
    }
}
