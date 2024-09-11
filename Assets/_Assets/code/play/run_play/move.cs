using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed = 5f;
    public float left_right;
    public Rigidbody2D rb;
    float horizontal = 0f;
    float vertical = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;  // Di chuyển sang phải
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f; // Di chuyển sang trái
        }
        else
        {
            horizontal= 0f;
        }

        // Xử lý trục dọc (Y-axis)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;  // Di chuyển lên trên
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f; // Di chuyển xuống dưới
        }
        else
        {
            vertical = 0f;
        }

        // Áp dụng vận tốc mới cho rigidbody, giữ nguyên giá trị cả 2 trục

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        //float left_right = Input.GetAxisRaw("Horizontal");
        //float up_down = Input.GetAxisRaw("Vertical");
        //rb.velocity = new Vector2(speed * left_right, speed * up_down);
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    left_right = 1;
        //    rb.velocity = new Vector2(speed * left_right, rb.velocity.y);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    left_right = -1;
        //    rb.velocity = new Vector2(speed * left_right, rb.velocity.y);
        //}
        //else
        //{
        //    left_right = 0;
        //    rb.velocity = new Vector2(speed * left_right, rb.velocity.y);
        //}
        //float left_right = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(speed * left_right, rb.velocity.y);
        //Debug.Log($"dfdfdfd{left_right}");
        //if(Input.GetKey(KeyCode.M))
        //{
        //    Debug.Log("da nhan vao A");
        //}    
    }

}
