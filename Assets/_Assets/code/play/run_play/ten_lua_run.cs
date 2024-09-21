using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ten_lua_run : MonoBehaviour
{
    public Transform tenlua; 
    public float rotationSpeed = 5f; 

    void Update()
    {
        if (tenlua != null)
        {
           
            Vector3 directionToPlayer =   transform.position-tenlua.position;

           
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

           
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));


            tenlua.transform.rotation = Quaternion.Slerp(tenlua.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
