using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 velocity;

    
    public float speed;
    void Start()
    {
        Destroy(this.gameObject,3f);
        rb= GetComponent<Rigidbody2D>();
        rb.velocity=transform.right*speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y<velocity.y)
        {
            rb.velocity=velocity;
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        rb.velocity=new Vector2 (velocity.x, -velocity.y);

        if(col.collider.tag=="enemy")
        {
            Destroy(col.gameObject);
            Explode();
        }

        if(col.contacts[0].normal.x!=0)
        {
            Explode();
        }

    }

    void Explode()
    {
        Destroy(this.gameObject);
    }
}

