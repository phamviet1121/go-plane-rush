﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_left_right : MonoBehaviour
{

    
    // public home_dk home_Dk_maybay;
    // public GameObject player;
     public float rotationSpeed = 1f;

    //// private float horizontalInput ;

    // private bool isMovingRight = false;
    // private bool isMovingLeft = false;


    // private void Start()
    // {


    // }

    private void Update()

    {
        // Kiểm tra nếu người dùng chạm vào màn hình
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Lấy vị trí chạm trên màn hình
            Vector2 touchPosition = touch.position;

            // Chia màn hình thành 2 nửa
            float screenMiddle = Screen.width / 2;

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Nếu chạm vào bên trái màn hình
                if (touchPosition.x < screenMiddle)
                {
                    traimover();
                }
                // Nếu chạm vào bên phải màn hình
                else if (touchPosition.x > screenMiddle)
                {
                    phaimover();
                }
                else
                {
                    dung();
                }
            }
        }
    }

    public void traimover()
    {
        Quaternion playerRotation = transform.rotation;
        Vector3 currentEulerAngles = playerRotation.eulerAngles;

        float newZAngle = currentEulerAngles.z + -1 * rotationSpeed;


        transform.rotation = Quaternion.Euler(0f, 180f, newZAngle);
        Debug.Log("chay sang trai");
    }
    public void phaimover()
    {

        Quaternion playerRotation = transform.rotation;
        Vector3 currentEulerAngles = playerRotation.eulerAngles;

        float newZAngle = currentEulerAngles.z + 1 * rotationSpeed;


        transform.rotation = Quaternion.Euler(0f, 180f, newZAngle);
        Debug.Log($"chay sang phai{transform.rotation}");

    }

    public void dung()
    {

        Quaternion playerRotation = transform.rotation;
        Vector3 currentEulerAngles = playerRotation.eulerAngles;

        float newZAngle = currentEulerAngles.z + 0 * rotationSpeed;


        transform.rotation = Quaternion.Euler(0f, 180f, newZAngle);
        Debug.Log("khong them chay ");
    }
}




// }
// public void StartMoveRight()
// {
//     isMovingRight = true;
// }

// public void StopMoveRight()
// {
//     isMovingRight = false;
// }

// public void StartMoveLeft()
// {
//     isMovingLeft = true;
// }

// public void StopMoveLeft()
// {
//     isMovingLeft = false;
// }


// public void phaimover()
// {

//     Quaternion playerRotation = player.transform.rotation;
//     Vector3 currentEulerAngles = playerRotation.eulerAngles;

//     float newZAngle = currentEulerAngles.z + -1 * rotationSpeed;


//     player.transform.rotation = Quaternion.Euler(0f, 180f, newZAngle);
//     Debug.Log($"chay sang phai{transform.rotation}");

// }

// public void dung()
// {

//     Quaternion playerRotation =player.transform.rotation;
//     Vector3 currentEulerAngles = playerRotation.eulerAngles;

//     float newZAngle = currentEulerAngles.z + 0 * rotationSpeed;


//     player.transform.rotation = Quaternion.Euler(0f, 180f, newZAngle);
//     Debug.Log("khong them chay ");
// }


