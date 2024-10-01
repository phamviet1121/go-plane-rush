using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public Transform location_player;
    public Transform target;
    public GameObject Notification_icon;
    public Canvas canvas;
    private GameObject NewNotification_Icon;
    void Start()
    {
       
        // Đảm bảo canvas đã được gán
        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
        }

        // Tạo ra instance cho thông báo, nhưng tạm thời ẩn nó
        NewNotification_Icon = Instantiate(Notification_icon, canvas.transform);
        NewNotification_Icon.SetActive(false); // Ẩn thông báo khi bắt đầu
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - location_player.position;
        Vector3 midPoint = location_player.position + direction;

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
            NewNotification_Icon.SetActive(true); // Hiện thông báo
            // Chuyển từ Screen Space sang Canvas Space
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPoint,
                canvas.worldCamera,
                out Vector2 localPoint);

            // Tính toán vị trí của thông báo ở biên canvas
            localPoint.x = Mathf.Clamp(localPoint.x, -canvasWidth / 2 /*+ padding*/, canvasWidth / 2 /*- padding*/);
            localPoint.y = Mathf.Clamp(localPoint.y, -canvasHeight / 2 /*+ padding*/, canvasHeight / 2 /* -padding*/);

            // Đặt lại vị trí của thông báo trên biên của canvas
            RectTransform thongbaoRect = NewNotification_Icon.GetComponent<RectTransform>();
            thongbaoRect.anchoredPosition = localPoint;
           
        }
        else
        {
            NewNotification_Icon.SetActive(false);

        }








    }
}
