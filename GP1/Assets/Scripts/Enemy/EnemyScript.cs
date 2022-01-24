using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemySpeed;
    public int hozMove;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit=Physics2D.Raycast (transform.position, new Vector2(hozMove,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (hozMove,0)* enemySpeed;

        if(hit.distance <0.7f)
        {
            Flip();
            if(hit.collider.tag=="Player")
            {
                Destroy (hit.collider.gameObject);
            }
        }
    }

    void Flip ()
    {
        if(hozMove >0)
            hozMove=-1;

        else
            hozMove=1;
    }
}
