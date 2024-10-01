using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

public class Creates_shields : MonoBehaviour
{

    public GameObject Icon_Shields;
    private GameObject newIcon_Shields;
    //public Transform player;
    public float TimeCreatedShields;
    public float NewTimeCreatedShields = 20f;
    public float number_shields = 0;
    public GameObject Shields;
    public GameObject new_Shields;

    public GameObject location;

    public GameObject Notification_icon_Shields;
    public Canvas canvas;
    private GameObject NewNotification_Icon_Shields;
    public float padding = 10f;
    public GameObject play;
     float newthoigianbatdau = 2f;

    float thoigianbatdau;
    private void Start()
    {
        if (canvas == null)
        {
           
            canvas = GetComponentInParent<Canvas>();
        }


        NewNotification_Icon_Shields = Instantiate(Notification_icon_Shields, canvas.transform);
        NewNotification_Icon_Shields.SetActive(false);
        padding = 10f;
    }
    void Update()
    {
        if (play.activeSelf == true)
        {
            thoigianbatdau -= Time.deltaTime;
        }
        else
        {
            thoigianbatdau = newthoigianbatdau;
        }



        TimeCreatedShields -= Time.deltaTime;
        if (TimeCreatedShields <= 0&& newIcon_Shields == null&& thoigianbatdau<=0)
        {
            Creates_iconShield();
             TimeCreatedShields = NewTimeCreatedShields;
        }
        if (number_shields > 0 && new_Shields == null)
        {
            Creates_Shield();
            number_shields -= 1;
          
        }
        if (new_Shields != null)
        {
            new_Shields.transform.position = transform.position;
        }
        
        if(newIcon_Shields != null)
        {
            Notification_Shield();
        }    


    }

   
    public void Creates_iconShield()
    {


        float a = (Random.value > 0.5f) ? Random.Range(5f, 10f) : Random.Range(-5f, -10f);
        float b = (Random.value > 0.5f) ? Random.Range(5f, 10f) : Random.Range(-5f, -10f);
        Vector2 Shieldlocation = new Vector2(location.transform.position.x + a, location.transform.position.y + b);


        newIcon_Shields=Instantiate(Icon_Shields, Shieldlocation, Quaternion.identity);
    }

    public void Creates_Shield()
    {
        Vector3 playerPosition = transform.position;
        new_Shields = Instantiate(Shields, playerPosition, Quaternion.identity);
    }
    public void Notification_Shield()
    {
        Vector3 direction = newIcon_Shields.transform.position - location.transform.position;
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
            NewNotification_Icon_Shields.SetActive(true); // Hiện thông báo
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
            RectTransform thongbaoRect = NewNotification_Icon_Shields.GetComponent<RectTransform>();
            thongbaoRect.anchoredPosition = localPoint;
           
        }
        else
        {
            NewNotification_Icon_Shields.SetActive(false);

        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("icon_Shields"))
        {
            number_shields += 1;

        }
    }
    private void OnDestroy()
    {
        if (newIcon_Shields != null)
        {
            Destroy(newIcon_Shields);
        }
        if (NewNotification_Icon_Shields != null)
        {
            Destroy(NewNotification_Icon_Shields);
        }
    }
}
