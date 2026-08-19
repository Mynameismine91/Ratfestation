using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Cam_driver : MonoBehaviour
{
   public Transform WatchMe;
   public float boundX = 0.15f;
   public float boundY = 0.5f;

   private void Start()
   {
      WatchMe = GameObject.Find("Cat").transform;
   }

   private void LateUpdate()
   {
         Vector3 delta = Vector3.zero;

//if were inside bounds on x
         float deltaX = WatchMe.position.x - transform.position.x;
         if (deltaX > boundX || deltaX  < -boundX)
         {
if (transform.position.x < WatchMe.position.x)
      {
      delta.x = deltaX - boundX;
      }
else 
      {
      delta.x = deltaX + boundX;
      }
         }
//if were inside bounds on y
         float deltaY = WatchMe.position.y - transform.position.y;
         if (deltaY > boundY || deltaY  < -boundY)
         {
if (transform.position.y < WatchMe.position.y)
      {
      delta.y = deltaY - boundY;
      }
else 
      {
      delta.y = deltaY + boundY;
      }
         }
   
 transform.position += new Vector3(delta.x, delta.y, 0);

   }
}

