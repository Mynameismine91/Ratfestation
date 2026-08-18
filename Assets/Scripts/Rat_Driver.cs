using UnityEngine;



public class Rat_Driver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public float Detection_range = 5; // this is the range or distance the food is from the rat before they start going straight for it
public bool locked_in; //the state wherein the rats are going straight to the food
public Transform foodtransform;
private Vector3 currentposition;


void Update()
    {
        
    }
private void FixedUpdate()
    {
        if (Vector3.Distance(foodtransform.position, currentposition) > Detection_range)
        {
            locked_in = true;
        }
    }
}
