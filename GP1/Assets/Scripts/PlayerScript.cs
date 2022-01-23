using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int JumpPower=1250;
    private bool facingRight= true;
    private float hozMove;
    void Start()
    {

    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if(Input.GetButtonDown ("Jump"))
        {      
            Jump();
        }

        hozMove= Input.GetAxis("Horizontal");
        
        if(hozMove<0.0f && facingRight==true)
        {
            FlipPlayer();
        }
        else if(hozMove>0.0f && facingRight==false)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity =new Vector2 (hozMove*speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up*JumpPower);
    }
    void FlipPlayer()
    {
        facingRight=! facingRight;
        Vector2 localScale =gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale=localScale;

    }
}
