using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vo_lang : MonoBehaviour
{
    public GameObject player; // Bi?n ??i di?n cho ??i t??ng player
    public float speed = 5f; // T?c ?? di chuy?n c?a player
    private bool touchStart = false; // Xác ??nh tr?ng thái ch?m
    private Vector2 pointA; // ?i?m b?t ??u khi ch?m vào màn hình
    private Vector2 pointB; // ?i?m hi?n t?i khi kéo chu?t ho?c ngón tay

    public Transform circle;       // Vòng tròn bên trong
    public Transform outercircle;  // Vòng tròn bên ngoài

    // Start is called before the first frame update
    void Start()
    {
        // Kh?i t?o các ??i t??ng và t?t hi?n th? ban ??u
        circle.GetComponent<SpriteRenderer>().enabled = false;
        outercircle.GetComponent<SpriteRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Phát hi?n lúc b?t ??u ch?m vào màn hình
        if (Input.GetMouseButtonDown(0))
        {
            // L?y v? trí con tr? chu?t ho?c ?i?m ch?m vào màn hình (screen space)
            pointA = Input.mousePosition;
            pointB = Input.mousePosition;

            // Chuy?n ??i t?a ?? màn hình thành t?a ?? cho UI (canvas 2D)
            circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x, pointA.y, Camera.main.nearClipPlane));
            outercircle.transform.position = circle.transform.position;

            // Hi?n th? các vòng tròn
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outercircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        // Xác ??nh khi ng??i dùng ?ang kéo chu?t ho?c ch?m vào màn hình
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Input.mousePosition;
        }
        else
        {
            touchStart = false;
        }
    }

    // FixedUpdate ???c g?i liên t?c v?i kho?ng th?i gian c? ??nh
    private void FixedUpdate()
    {
        if (touchStart)
        {
            // Tính toán kho?ng cách gi?a ?i?m A và B
            Vector2 offset = pointB - pointA;
            Vector2 offset1 = new Vector2(offset.y, offset.x);

            Vector2 d = Vector2.ClampMagnitude(offset1, 100f); // ?i?u ch?nh ?? nh?y

            // Di chuy?n nhân v?t theo h??ng kéo
            movercharecter(d.normalized);

            // C?p nh?t v? trí c?a vòng tròn nh? ?? theo dõi v? trí kéo
            circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((pointA.x + d.y), (pointA.y + d.x), Camera.main.nearClipPlane));
        }
        else
        {
            // T?t hi?n th? các vòng tròn khi không ch?m vào màn hình
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outercircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Hàm di chuy?n player theo h??ng ???c ch? ??nh
    void movercharecter(Vector2 d)
    {
        player.transform.Translate(d * speed * Time.deltaTime); // S? d?ng Translate ?? di chuy?n
    }

}