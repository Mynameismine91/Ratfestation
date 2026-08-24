using UnityEngine;

public class Food : MonoBehaviour
{
private Gamemanager GM;
    void Start()
    {
        Debug.Log("meow");

        if (GM == null)
    {
        GameObject gmObject = GameObject.Find("Gamemanager");

        if (gmObject != null)
        {
            GM = gmObject.GetComponent<Gamemanager>();
        }
    }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rat"))
        {
        Debug.Log("bruh");
        GM.points--;
        GM.UpdateScoreText();
        Destroy(gameObject, 3);
        }
        
    }
}
