using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class move_camara : MonoBehaviour
{
    public GameObject camara;
    public Vector3 offset;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        camara.transform.position = transform.position+ offset;
      
    }
}
