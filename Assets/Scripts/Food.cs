using UnityEngine;

public class Food : MonoBehaviour
{
    void Start()
    {
        Debug.Log("meow");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bruh");
        Destroy(gameObject, 3);
        
    }
}
