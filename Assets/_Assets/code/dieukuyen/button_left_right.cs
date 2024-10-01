using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_left_right : MonoBehaviour
{

    
   
     public float rotationSpeed = 1f;
    public float movementSpeed = 5f;
   
    private void Update()

    {
      
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

           
            Vector2 touchPosition = touch.position;

           
            float screenMiddle = Screen.width / 2;

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
              
                if (touchPosition.x < screenMiddle)
                {
                    traimover();
                }
              
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
       // DiChuyenTheoGocQuay();
    }

    public void traimover()
    {
        Quaternion playerRotation = transform.rotation;
        Vector3 currentEulerAngles = playerRotation.eulerAngles;

        float newZAngle = currentEulerAngles.z + 1 * rotationSpeed;


        transform.rotation = Quaternion.Euler(0f, 0f, newZAngle);
      
    }
    public void phaimover()
    {

        Quaternion playerRotation = transform.rotation;
        Vector3 currentEulerAngles = playerRotation.eulerAngles;

        float newZAngle = currentEulerAngles.z + -1 * rotationSpeed;


        transform.rotation = Quaternion.Euler(0f, 0f, newZAngle);
      

    }

    public void dung()
    {

        Quaternion playerRotation = transform.rotation;
        Vector3 currentEulerAngles = playerRotation.eulerAngles;

        float newZAngle = currentEulerAngles.z + 0 * rotationSpeed;


        transform.rotation = Quaternion.Euler(0f, 0, newZAngle);
       
    }
    private void DiChuyenTheoGocQuay()
    {
       
        float angle = transform.eulerAngles.z;

        
        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

       
        transform.position += direction * movementSpeed * Time.deltaTime;

       
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



