using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
   void OnTriggerEnter2D (Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
           Pickup();
       }
   }

   void Pickup()
   {
       Debug.Log("Picked up");
       Destroy(gameObject);
   }
}
