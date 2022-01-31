using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemySpeed;
    public int hozMove;
    public Animator animator;

    Rigidbody2D rb;
    
    // Start is called before the first frame update
    

    // Update is called once per frame

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        RaycastHit2D hit=Physics2D.Raycast(transform.position, new Vector2 (hozMove,0));
        rb.velocity= new Vector2 (hozMove,0)*enemySpeed;

        if(hit.distance<0.5f)
        {
            Flip ();
        }
    }

    void Flip ()
    {
        if(hozMove >0)
            hozMove=-1;

        else
            hozMove=1;
    }

    void Die()
    {
        RaycastHit2D hit=Physics2D.Raycast (transform.position,Vector2.up);
        if(hit.collider!= null && hit.distance < 0.5f && hit.collider.tag=="Player")
        {
            animator.SetBool("Died",true);
        }
    }
}
