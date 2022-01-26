using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptV2 : MonoBehaviour
{
    public GameObject target;
    public GameObject target2;
    public GameObject target3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x+5, this.transform.position.y, this.transform.position.z);
    }
}
