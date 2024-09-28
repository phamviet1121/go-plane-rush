using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class move_camara : MonoBehaviour
{
    public GameObject camara;
    public Vector3 offset;
    //public float smoothSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        camara.transform.position = transform.position+ offset;
        //camara.transform.position = Vector3.Lerp(camara.transform.position, targetPosition, smoothSpeed);
    }
}
