using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vo_lang : MonoBehaviour
{
    //public Transform player;
    public RectTransform tam;
    public RectTransform vongtron;
    
    public float speed=5f;

    // Bán kính của vòng tròn
    public float radius = 2f;
    public float radius2 = 2f;
    public float rotationSpeed = 3f;

    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 vitri_nguoidung_an = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 vitrian = new Vector2(vitri_nguoidung_an.x, vitri_nguoidung_an.y);

                // Chỉ thực hiện khi khoảng cách giữa điểm chạm và tâm là nhỏ hơn bán kính ngoài (radius2)
                if (Vector2.Distance(vitrian, vongtron.transform.position) <= radius2)
                {
                    Vector2 direction = vitrian - new Vector2(vongtron.transform.position.x, vongtron.transform.position.y);
                    float distance = direction.magnitude;

                    // Nếu khoảng cách lớn hơn bán kính bên trong, thì điều chỉnh vị trí
                    if (distance > radius)
                    {
                        direction.Normalize(); // Chuẩn hóa vector để có độ dài = 1
                        tam.transform.position = vongtron.transform.position + (Vector3)(direction * radius); // Đặt `tam` tại điểm trên vòng tròn
                    }
                    else
                    {
                        // Di chuyển `tam` đến vị trí người dùng chạm nếu khoảng cách nhỏ hơn bán kính trong
                        tam.transform.position = Vector2.MoveTowards(tam.transform.position, vitrian, speed * Time.deltaTime);
                    }

                    // Tính toán góc quay của `player` dựa trên vị trí của `tam`
                    Vector2 gocquay = vitrian-new Vector2(tam.position.x, tam.position.y);
                    float angle = Mathf.Atan2(gocquay.y, gocquay.x) * Mathf.Rad2Deg; // Tính góc từ vị trí `tam`
                    Debug.Log($"{angle}");

                    Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Quay trên trục Z
                    Debug.Log($"{targetRotation}");
                    //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); // Xoay mượt
                    //Debug.Log($"{player.transform.rotation}");
                    //player.transform.rotation= Quaternion.Euler(new Vector3(0f, 180f, angle));
                   transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); // Xoay mượt
                }
            }
        }
        else
        {
            // Di chuyển `tam` trở về vị trí ban đầu (vongtron) khi không có người dùng chạm
            tam.transform.position = Vector2.MoveTowards(tam.transform.position, vongtron.transform.position, (speed + 5) * Time.deltaTime);
        }
    }


    //public GameObject player; // Bi?n ??i di?n cho ??i t??ng player
    //public float speed = 5f; // T?c ?? di chuy?n c?a player
    //private bool touchStart = false; // Xác ??nh tr?ng thái ch?m
    //private Vector2 pointA; // ?i?m b?t ??u khi ch?m vào màn hình
    //private Vector2 pointB; // ?i?m hi?n t?i khi kéo chu?t ho?c ngón tay

    //public Transform circle;       // Vòng tròn bên trong
    //public Transform outercircle;  // Vòng tròn bên ngoài

    //// Start is called before the first frame update
    //void Start()
    //{
    //    // Kh?i t?o các ??i t??ng và t?t hi?n th? ban ??u
    //    circle.GetComponent<SpriteRenderer>().enabled = false;
    //    outercircle.GetComponent<SpriteRenderer>().enabled = false;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Phát hi?n lúc b?t ??u ch?m vào màn hình
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // L?y v? trí con tr? chu?t ho?c ?i?m ch?m vào màn hình (screen space)
    //        pointA = Input.mousePosition;
    //        pointB = Input.mousePosition;

    //        // Chuy?n ??i t?a ?? màn hình thành t?a ?? cho UI (canvas 2D)
    //        circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x, pointA.y, Camera.main.nearClipPlane));
    //        outercircle.transform.position = circle.transform.position;

    //        // Hi?n th? các vòng tròn
    //        circle.GetComponent<SpriteRenderer>().enabled = true;
    //        outercircle.GetComponent<SpriteRenderer>().enabled = true;
    //    }

    //    // Xác ??nh khi ng??i dùng ?ang kéo chu?t ho?c ch?m vào màn hình
    //    if (Input.GetMouseButton(0))
    //    {
    //        touchStart = true;
    //        pointB = Input.mousePosition;
    //    }
    //    else
    //    {
    //        touchStart = false;
    //    }
    //}

    //// FixedUpdate ???c g?i liên t?c v?i kho?ng th?i gian c? ??nh
    //private void FixedUpdate()
    //{
    //    if (touchStart)
    //    {
    //        // Tính toán kho?ng cách gi?a ?i?m A và B
    //        Vector2 offset = pointB - pointA;
    //        Vector2 offset1 = new Vector2(offset.y, offset.x);

    //        Vector2 d = Vector2.ClampMagnitude(offset1, 100f); // ?i?u ch?nh ?? nh?y

    //        // Di chuy?n nhân v?t theo h??ng kéo
    //        movercharecter(d.normalized);

    //        // C?p nh?t v? trí c?a vòng tròn nh? ?? theo dõi v? trí kéo
    //        circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((pointA.x + d.y), (pointA.y + d.x), Camera.main.nearClipPlane));
    //    }
    //    else
    //    {
    //        // T?t hi?n th? các vòng tròn khi không ch?m vào màn hình
    //        circle.GetComponent<SpriteRenderer>().enabled = false;
    //        outercircle.GetComponent<SpriteRenderer>().enabled = false;
    //    }
    //}

    //// Hàm di chuy?n player theo h??ng ???c ch? ??nh
    //void movercharecter(Vector2 d)
    //{
    //    player.transform.Translate(d * speed * Time.deltaTime); // S? d?ng Translate ?? di chuy?n
    //}

}