using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vo_lang : MonoBehaviour
{


    public FixedJoystick joystick;

    public float rotationSpeed = 1f;
    public float movementSpeed = 5f;

    void Start()
    {
    }

    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        if (horizontal != 0 || vertical != 0)
        {
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        //DiChuyenTheoGocQuay();
      
    }
   
    private void DiChuyenTheoGocQuay()
    {
      
        float angle = transform.eulerAngles.z;

       
        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

       
        transform.position += direction * movementSpeed * Time.deltaTime;

        Debug.Log($"Di chuyển theo góc quay: {angle}, hướng: {direction}");
    }


}