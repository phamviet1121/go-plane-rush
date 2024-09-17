using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ten_lua_run : MonoBehaviour
{
    public Transform player; 
    public float rotationSpeed = 5f; 

    void Update()
    {
        if (player != null)
        {
           
            Vector3 directionToPlayer = player.position - transform.position;

           
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

           
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
