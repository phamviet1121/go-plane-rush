using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_left_right : MonoBehaviour
{
    public GameObject player;
    public Button right;
    public Button left;
    public float rotationSpeed = 1f;

    private float horizontalInput = 0f;
   

    private void Start()
    {
       
      
    }

    private void Update()
    {
       
        if (Input.GetButtonDown("Button (Legacy)_right"))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetButtonDown("Button (Legacy)_left"))
        {
            horizontalInput = 1f;
        }
        else
        {
            horizontalInput = 0f;
        }

       
        Vector3 currentEulerAngles = player.transform.eulerAngles;
        float newZAngle = currentEulerAngles.z + horizontalInput * rotationSpeed;

       
        player.transform.rotation = Quaternion.Euler(currentEulerAngles.x, currentEulerAngles.y, newZAngle);
    }

    
}
