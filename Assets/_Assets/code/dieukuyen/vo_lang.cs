using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vo_lang : MonoBehaviour
{
    public GameObject player; // Bi?n ??i di?n cho ??i t??ng player
    public float speed = 5f; // T?c ?? di chuy?n c?a player
    private bool touchStart = false; // X�c ??nh tr?ng th�i ch?m
    private Vector2 pointA; // ?i?m b?t ??u khi ch?m v�o m�n h�nh
    private Vector2 pointB; // ?i?m hi?n t?i khi k�o chu?t ho?c ng�n tay

    public Transform circle;       // V�ng tr�n b�n trong
    public Transform outercircle;  // V�ng tr�n b�n ngo�i

    // Start is called before the first frame update
    void Start()
    {
        // Kh?i t?o c�c ??i t??ng v� t?t hi?n th? ban ??u
        circle.GetComponent<SpriteRenderer>().enabled = false;
        outercircle.GetComponent<SpriteRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Ph�t hi?n l�c b?t ??u ch?m v�o m�n h�nh
        if (Input.GetMouseButtonDown(0))
        {
            // L?y v? tr� con tr? chu?t ho?c ?i?m ch?m v�o m�n h�nh (screen space)
            pointA = Input.mousePosition;
            pointB = Input.mousePosition;

            // Chuy?n ??i t?a ?? m�n h�nh th�nh t?a ?? cho UI (canvas 2D)
            circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(pointA.x, pointA.y, Camera.main.nearClipPlane));
            outercircle.transform.position = circle.transform.position;

            // Hi?n th? c�c v�ng tr�n
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outercircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        // X�c ??nh khi ng??i d�ng ?ang k�o chu?t ho?c ch?m v�o m�n h�nh
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

    // FixedUpdate ???c g?i li�n t?c v?i kho?ng th?i gian c? ??nh
    private void FixedUpdate()
    {
        if (touchStart)
        {
            // T�nh to�n kho?ng c�ch gi?a ?i?m A v� B
            Vector2 offset = pointB - pointA;
            Vector2 offset1 = new Vector2(offset.y, offset.x);

            Vector2 d = Vector2.ClampMagnitude(offset1, 100f); // ?i?u ch?nh ?? nh?y

            // Di chuy?n nh�n v?t theo h??ng k�o
            movercharecter(d.normalized);

            // C?p nh?t v? tr� c?a v�ng tr�n nh? ?? theo d�i v? tr� k�o
            circle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((pointA.x + d.y), (pointA.y + d.x), Camera.main.nearClipPlane));
        }
        else
        {
            // T?t hi?n th? c�c v�ng tr�n khi kh�ng ch?m v�o m�n h�nh
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outercircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // H�m di chuy?n player theo h??ng ???c ch? ??nh
    void movercharecter(Vector2 d)
    {
        player.transform.Translate(d * speed * Time.deltaTime); // S? d?ng Translate ?? di chuy?n
    }

}