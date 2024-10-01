using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goc_quay : MonoBehaviour
{

    public float rotationSpeed = 1f;
    public float movementSpeed = 5f;
    bool accelerate = false;
    public float TimeAccelerate;
    public float NewTimeAccelerate = 10f;

    void Update()
    {
        TimeAccelerate -= Time.deltaTime;
        if (TimeAccelerate <= 0)
        {
            accelerate = false;
        }


        DiChuyenTheoGocQuay();
    }
    private void DiChuyenTheoGocQuay()
    {
        float angle = transform.eulerAngles.z;


        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

        if (accelerate)
        {
            transform.position += direction * (movementSpeed+2f) * Time.deltaTime;
        }
        else
        {
            transform.position += direction * movementSpeed  * Time.deltaTime;
        }




    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Accelerate"))
        {
            accelerate = true;
            TimeAccelerate = NewTimeAccelerate;
        }
    }

}
