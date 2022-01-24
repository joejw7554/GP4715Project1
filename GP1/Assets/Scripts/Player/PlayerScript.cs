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

    public Animator animator;


    void Start()
    {
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
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

    }

    void PlayerRaycast ()
    {
        //Todo Fix 
        RaycastHit2D rayUp=Physics2D.Raycast (transform.position, Vector2.up);
        if(rayUp !=null && rayUp.collider != null && rayUp.distance < 0.9f && rayUp.collider.name=="Randombox")
        {
            Destroy(rayUp.collider.gameObject);

        }


        RaycastHit2D rayDown=Physics2D.Raycast (transform.position, Vector2.down);

        if(rayDown !=null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag=="enemy")
        {
            GetComponent<Rigidbody2D>().AddForce (Vector2.up* 3);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale=8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation= false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            rayDown.collider.gameObject.GetComponent<EnemyScript>().enabled=false;

        }
        if(rayDown !=null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag!="enemy")
        {
            isGrounded=true;
        }
    }
}
