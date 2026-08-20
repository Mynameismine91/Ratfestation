using UnityEngine;

public class Cat_Driver : MonoBehaviour
{
    [SerializeField] float catSpeed = 5f;
    [SerializeField] Transform obj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(x, y, 0);
        tempVect = tempVect.normalized * catSpeed * Time.deltaTime;

        obj.transform.position += tempVect;


     Vector3 position = transform.position; //boundary
    position.y = Mathf.Clamp(position.y, -30.5f, 30f);
    position.x = Mathf.Clamp(position.x, -30.5f, 30f);    
    transform.position = position;
    }
}
