using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
 

    void Start()
    {

    }
    void Update()
    {
        if(gameObject.transform.position.y<-3)
        {
            Die();
        }
    }

    void Die ()
    {
        SceneManager.LoadScene ("Level1");
    }
}
