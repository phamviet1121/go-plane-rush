using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction : MonoBehaviour
{
    public GameObject icon_destruction;
    public float TimeCreatedDestruction;
    public float NewTimeCreatedDestruction = 30f;
    public GameObject location;
    public GameObject newDestruction;


    public GameObject Notification_icon_Destruction;
    public Canvas canvas;
    private GameObject NewNotification_Icon_Destruction;
    public float padding = 10f;
    void Start()
    {
        if (canvas == null)
        {

            canvas = GetComponentInParent<Canvas>();
        }


        NewNotification_Icon_Destruction = Instantiate(Notification_icon_Destruction, canvas.transform);
        NewNotification_Icon_Destruction.SetActive(false);
        padding = 10f;
        TimeCreatedDestruction = NewTimeCreatedDestruction;
    }

    void Update()
    {

        if (newDestruction == null)
        {

            TimeCreatedDestruction -= Time.deltaTime;
            if (TimeCreatedDestruction <= 0)
            {
                BornSpeed();
                TimeCreatedDestruction = NewTimeCreatedDestruction;

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
        newDestruction = Instantiate(icon_destruction, Starlocation, Quaternion.identity);
    }
    public void Notification_Accelerate()
    {
        Vector3 direction = newDestruction.transform.position - location.transform.position;
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
            NewNotification_Icon_Destruction.SetActive(true); // Hiện thông báo
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
            RectTransform thongbaoRect = NewNotification_Icon_Destruction.GetComponent<RectTransform>();
            thongbaoRect.anchoredPosition = localPoint;

        }
        else
        {
            NewNotification_Icon_Destruction.SetActive(false);

        }
    }
}