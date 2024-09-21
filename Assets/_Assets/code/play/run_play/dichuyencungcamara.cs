using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyencungcamara : MonoBehaviour
{
    public Transform camara;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camara.position+offset;
    }
}
