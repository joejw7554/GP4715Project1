using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int speed;
    public int hozMove;

    void Update()
    {
        RaycastHit2D hit=Physics2D.Raycast (transform.position, new Vector2(hozMove,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (hozMove*speed,0);

        if(hit.distance <0.7f)
        {
            Flip();
        }
    }
    void Flip()
    {
        if(hozMove >0)
        {
            hozMove=-1;
        }
        else
        {
            hozMove=1;
        }
    }
}
