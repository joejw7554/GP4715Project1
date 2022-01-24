using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthScrpit : MonoBehaviour
{
    void Update()
    {
             if(gameObject.transform.position.y<-3)
        {
            Destroy (gameObject);
        }
    }
}
