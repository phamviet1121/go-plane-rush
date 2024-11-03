using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class move_camara : MonoBehaviour
{
    public GameObject camara;
    public GameObject cavarmacdinh;
    public Vector3 offset;
    public float smoothSpeed = 3f; // Điều chỉnh giá trị này để mượt mà hơn
    public float stoppingDistance = 0.01f; // Khoảng cách để dừng nội suy
    Vector3 targetPosition;
    void Start()
    {
        smoothSpeed = 7f;
        // Cài đặt offset ban đầu dựa vào trạng thái của cavarhome
        offset = cavarmacdinh.activeSelf ? new Vector3(0, -1.4f, -10) : new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (cavarmacdinh.activeSelf == false)
        {

            offset = new Vector3(0, 0, -10);
            targetPosition = transform.position + offset;
            if (Vector3.Distance(camara.transform.position, targetPosition) > stoppingDistance)
            {
                // Nội suy mượt mà vị trí của camera
                camara.transform.position = Vector3.Lerp(camara.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            }
            else
            {
                // Gán trực tiếp vị trí khi gần đạt đến targetPosition
                camara.transform.position = targetPosition;

            }
           
        }
        else
        {

            offset = new Vector3(0, -1.4f, -10);

            targetPosition = transform.position + offset;
            camara.transform.position = targetPosition;
        }
        ////  Vector3 targetPosition = transform.position + offset;

        //if (Vector3.Distance(camara.transform.position, targetPosition) > stoppingDistance)
        //{
        //    // Nội suy mượt mà vị trí của camera
        //    camara.transform.position = Vector3.Lerp(camara.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    // Gán trực tiếp vị trí khi gần đạt đến targetPosition
        //    camara.transform.position = targetPosition;
        //}
        //// camara.transform.position = transform.position + offset;
    }
}
