using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CreatedStars : MonoBehaviour
{
    public GameObject Star;
    public float TimeCreatedStars;
    public float NewTimeCreatedStars = 10f;
    public GameObject location;
    public GameObject newStar;

    public GameObject Notification_icon_Star;
    public Canvas canvas;
    private GameObject NewNotification_Icon_Star;
    public float padding = 10f;

    void Start()
    {
        if (canvas == null)
        {
          
            canvas = GetComponentInParent<Canvas>();
        }
       

        NewNotification_Icon_Star = Instantiate(Notification_icon_Star, canvas.transform);
        NewNotification_Icon_Star.SetActive(false);
        padding = 10f;
    }

    void Update()
    {

        if (newStar == null)
        {

            TimeCreatedStars -= Time.deltaTime;
            if (TimeCreatedStars <= 0)
            {
                BornStar();
                TimeCreatedStars = NewTimeCreatedStars;

            }


        }
        if (newStar != null)
        {
            Notification_Star();
        }


    }
    public void BornStar()
    {
        float a = (Random.value > 0.5f) ? Random.Range(5f, 10f) : Random.Range(-5f, -10f);
        float b = (Random.value > 0.5f) ? Random.Range(5f, 10f) : Random.Range(-5f, -10f);
        Vector2 Starlocation = new Vector2(location.transform.position.x + a, location.transform.position.y + b);
        newStar = Instantiate(Star, Starlocation, Quaternion.identity);
    }
    public void Notification_Star()
    {
        Vector3 direction = newStar.transform.position - location.transform.position;
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
            NewNotification_Icon_Star.SetActive(true); // Hiện thông báo
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
            RectTransform thongbaoRect = NewNotification_Icon_Star.GetComponent<RectTransform>();
            thongbaoRect.anchoredPosition = localPoint;
           
        }
        else
        {
            NewNotification_Icon_Star.SetActive(false);

        }
    }

}
