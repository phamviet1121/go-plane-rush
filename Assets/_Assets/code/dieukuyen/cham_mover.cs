using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamMover : MonoBehaviour
{
  
    public float rotationSpeed = 12f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
           
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; 

            
            Vector3 directionToPlayer = mousePosition - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, -directionToPlayer.x) * Mathf.Rad2Deg;

            
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
