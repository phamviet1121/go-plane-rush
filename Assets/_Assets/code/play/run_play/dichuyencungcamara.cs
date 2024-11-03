using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyencungcamara : MonoBehaviour
{
    public Transform camara;
    public Vector3 offset;
    public GameObject cavarmacdinh;

    // Start is called before the first frame update
    void Start()
    {
        if (cavarmacdinh.activeSelf == false)
        {

            offset = new Vector3(0, 0, -10);
        }
        else
        {

            offset = new Vector3(0, 1.5f, -10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camara.position+offset;
    }
}
