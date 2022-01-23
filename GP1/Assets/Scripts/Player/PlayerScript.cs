using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed;
    private bool facingRight=false;
    public int playerJump;
    private float hozMove;
    public bool isGrounded;

    bool jump=false;

    public Animator animator;


    void Start()
    {
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        hozMove= Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(hozMove));
        
        if(Input.GetButtonDown("Jump") && isGrounded==true)
        {
            Jump();
        }

        if(hozMove<0.0f && facingRight==false)
        {
            FlipPlayer();
        }
        else if(hozMove > 0.0f && facingRight==true)
        {
            FlipPlayer();
        }


        gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2 (hozMove*speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up *playerJump);
        animator.SetBool("IsJumping",true);
        isGrounded=false;
    }

    void FlipPlayer()
    {
        facingRight=!facingRight;
        Vector2 localScale= gameObject.transform.localScale;
        localScale.x*=-1;
        transform.localScale=localScale;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Player has collided with" + collision.collider.name);

        if(collision.gameObject.tag=="ground")
        {
            isGrounded=true;
            animator.SetBool("IsJumping",false);
        }
    }
}
