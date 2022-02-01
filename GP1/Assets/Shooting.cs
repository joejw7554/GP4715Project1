using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;

    public PlayerScript Script1;
  

    // Update is called once per frame
    void Awake()
    {
        Script1=GameObject.FindObjectOfType<PlayerScript>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(fireballPrefab,firePoint.position, firePoint.rotation);
    }
}
