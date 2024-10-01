using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    public GameObject icon_Speed;
    public float TimeCreatedSpeed;
    public float NewTimeCreatedSpeed = 10f;
    public GameObject location;
    public GameObject newSpeed;


    public GameObject Notification_icon_Accelerate;
    public Canvas canvas;
    private GameObject NewNotification_Icon_Accelerate;
    public float padding = 10f;
    void Start()
    {
        if (canvas == null)
        {

            canvas = GetComponentInParent<Canvas>();
        }


        NewNotification_Icon_Accelerate = Instantiate(Notification_icon_Accelerate, canvas.transform);
        NewNotification_Icon_Accelerate.SetActive(false);
        padding = 10f;
    }

    void Update()
    {

        if (newSpeed == null)
        {

            TimeCreatedSpeed -= Time.deltaTime;
            if (TimeCreatedSpeed <= 0)
            {
                BornSpeed();
                TimeCreatedSpeed = NewTimeCreatedSpeed;

            }


        }
        else
        {
            Notification_Accelerate();
        }


    }
    public void BornSpeed()
    {
        float a = (Random.value > 0.5f) ? Random.Range(5f, 10f) : Random.Range(-5f, -10f);
        float b = (Random.value > 0.5f) ? Random.Range(5f, 10f) : Random.Range(-5f, -10f);
        Vector2 Starlocation = new Vector2(location.transform.position.x + a, location.transform.position.y + b);
        newSpeed = Instantiate(icon_Speed, Starlocation, Quaternion.identity);
    }
    public void Notification_Accelerate()
    {
        Vector3 direction = newSpeed.transform.position - location.transform.position;
        Vector3 midPoint = location.transform.position + direction;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(midPoint);

        RectTransform canvasRect = canvas.transform as RectTransform;

        float canvasWidth = canvasRect.rect.width;
        float canvasHeight = canvasRect.rect.height;

        bool isWithinCanvas = screenPoint.z > 0 &&
                              screenPoint.x > 0 && screenPoint.x < Screen.width &&
                              screenPoint.y > 0 && screenPoint.y < Screen.height;

        // Nếu 'dich' nằm ngoài canvas, hiện thông báo
        if (!isWithinCanvas)
        {
            NewNotification_Icon_Accelerate.SetActive(true); // Hiện thông báo
            // Chuyển từ Screen Space sang Canvas Space
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPoint,
                canvas.worldCamera,
                out Vector2 localPoint);

            // Tính toán vị trí của thông báo ở biên canvas
            localPoint.x = Mathf.Clamp(localPoint.x, -canvasWidth / 2 + padding, canvasWidth / 2 - padding);
            localPoint.y = Mathf.Clamp(localPoint.y, -canvasHeight / 2 + padding, canvasHeight / 2 - padding);

            // Đặt lại vị trí của thông báo trên biên của canvas
            RectTransform thongbaoRect = NewNotification_Icon_Accelerate.GetComponent<RectTransform>();
            thongbaoRect.anchoredPosition = localPoint;
           
        }
        else
        {
            NewNotification_Icon_Accelerate.SetActive(false);

        }
    }
}
