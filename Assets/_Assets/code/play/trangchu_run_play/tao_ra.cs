using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class tao_ra : MonoBehaviour
{
    public GameObject gameObj_1;
    public GameObject gameObj_2;
    public GameObject gameObj_3;
    public GameObject gameObj_4;
    public GameObject gameObj_5;
    public GameObject gameObj_6;
    public GameObject gameObj_7;
    public GameObject gameObj_8;
    public GameObject gameObj_9;
    public Transform parentObject;
    public float luanewtime = 2;
    float m_luanewtime;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            taora_may();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //// L?y g�c quay c?a nh�n v?t
        //Vector3 eulerAngles = transform.rotation.eulerAngles;
        //float z = eulerAngles.z;

        //// Chuy?n ??i g�c quay th�nh t? l? t? 0 ??n 1
        //float m = z / 360;

        //float c;
        //float d ; // Kho?ng c�ch c? ??nh d

        //// Th?c hi?n c�c h�nh ??ng kh�c nhau t�y thu?c v�o t? l? g�c quay
        //if (m <= 0.45f && m >= 0.05f)
        //{
        //    c = Random.Range(-6, 6);
        //     d = 10;
        //    // Th?c hi?n h�nh ??ng v?i c v� d
        //}
        //else if (m >= 0.35f && m <= 0.65f)
        //{
        //    c =-6;
        //    d= Random.Range(-6, 6);
        //    // Th?c hi?n h�nh ??ng v?i c v� d
        //}
        //else if (m >= 0.55f && m <= 0.85f)
        //{
        //    c = Random.Range(-6, 6);
        //    d = -10;
        //}
        //else
        //{
        //    c = 6;
        //    d = Random.Range(-6, 6);
        //}

        // Gi?m th?i gian v� ki?m tra
        //m_luanewtime -= Time.deltaTime;
        //if (m_luanewtime <= 0)
        //{
        //    taora_may(/*c, d*/);
        //    m_luanewtime = luanewtime;
        //}

    }
    public void taora_may(/*float c, float d*/)
    {
        //Vector2 position = new Vector2(transform.position.x + c, transform.position.y + d);
        //int b = Random.Range(0, 10);

        //// S? d?ng switch-case ?? l?a ch?n game object
        //switch (b)
        //{
        //    case 1:
        //        Instantiate(gameObj_1, position, Quaternion.identity);
        //        break;
        //    case 2:
        //        Instantiate(gameObj_2, position, Quaternion.identity);
        //        break;
        //    case 3:
        //        Instantiate(gameObj_3, position, Quaternion.identity);
        //        break;
        //    case 4:
        //        Instantiate(gameObj_4, position, Quaternion.identity);
        //        break;
        //    case 5:
        //        Instantiate(gameObj_5, position, Quaternion.identity);
        //        break;
        //    case 6:
        //        Instantiate(gameObj_6, position, Quaternion.identity);
        //        break;
        //    case 7:
        //        Instantiate(gameObj_7, position, Quaternion.identity);
        //        break;
        //    case 8:
        //        Instantiate(gameObj_8, position, Quaternion.identity);
        //        break;
        //    case 9:
        //        Instantiate(gameObj_9, position, Quaternion.identity);
        //        break;
        //    default:
        //        Debug.LogWarning("Random value out of range.");
        //        break;
        //}



        float c = Random.Range(-100, 100);
        float d = Random.Range(-100, 100);
        Vector2 a = new Vector2(transform.position.x + c, transform.position.y + d);
        int b = Random.Range(0, 10);
        GameObject createdObject = null;
        if (b == 1)
        {
            createdObject = Instantiate(gameObj_1, a, Quaternion.identity);
        }
        else if (b == 2)
        {
            createdObject = Instantiate(gameObj_2, a, Quaternion.identity);
        }
        else if (b == 3)
        {
            createdObject = Instantiate(gameObj_3, a, Quaternion.identity);
        }
        else if (b == 4)
        {
            createdObject = Instantiate(gameObj_4, a, Quaternion.identity);
        }
        else if (b == 5)
        {
            createdObject = Instantiate(gameObj_5, a, Quaternion.identity);
        }
        else if (b == 6)
        {
            createdObject = Instantiate(gameObj_6, a, Quaternion.identity);
        }
        else if (b == 7)
        {
            createdObject = Instantiate(gameObj_7, a, Quaternion.identity);
        }
        else if (b == 8)
        {
            createdObject = Instantiate(gameObj_8, a, Quaternion.identity);
        }
        else if (b == 9)
        {
            createdObject = Instantiate(gameObj_9, a, Quaternion.identity);
        }
        if (createdObject != null)
        {
            createdObject.transform.parent = parentObject; // Thi?t l?p parent cho game object m?i

            // Th�m collider v� RigidBody n?u ch?a c�
            if (createdObject.GetComponent<Collider2D>() == null)
            {
                createdObject.AddComponent<BoxCollider2D>(); // Thay ??i theo lo?i collider b?n c?n
            }

            if (createdObject.GetComponent<Rigidbody2D>() == null)
            {
                Rigidbody2D rb = createdObject.AddComponent<Rigidbody2D>();
                rb.isKinematic = true; // ?? kh�ng b? ?nh h??ng b?i v?t l�
            }


        }

    }
    //public void taora_may()
    //{
    //    // Gi? s? b?n c� m?t tham chi?u t?i transform c?a nh�n v?t ng??i ch?i
    //    Transform playerTransform = transform; // Thay th? v?i transform c?a nh�n v?t ng??i ch?i th?c t?

    //    // L?y h??ng quay c?a nh�n v?t ng??i ch?i
    //    Vector3 playerForward = playerTransform.forward;

    //    // X�c ??nh h??ng m� nh�n v?t ?ang ??i di?n
    //    int gameObjectIndex = 0;

    //    if (Mathf.Abs(playerForward.x) > Mathf.Abs(playerForward.y))
    //    {
    //        // Nh�n v?t ?ang ??i di?n g?n h??ng tr?c x
    //        if (playerForward.x > 0)
    //        {
    //            // Nh�n v?t ?ang ??i di?n v? ph�a b�n ph?i
    //            gameObjectIndex = Random.Range(0, 5); // S? d?ng m?t d?i s? cho h??ng x
    //        }
    //        else
    //        {
    //            // Nh�n v?t ?ang ??i di?n v? ph�a b�n tr�i
    //            gameObjectIndex = Random.Range(5, 10); // S? d?ng m?t d?i s? kh�c cho h??ng x
    //        }
    //    }
    //    else
    //    {
    //        // Nh�n v?t ?ang ??i di?n g?n h??ng tr?c y
    //        if (playerForward.y > 0)
    //        {
    //            // Nh�n v?t ?ang ??i di?n l�n ph�a tr�n
    //            gameObjectIndex = Random.Range(10, 15); // S? d?ng m?t d?i s? cho h??ng y
    //        }
    //        else
    //        {
    //            // Nh�n v?t ?ang ??i di?n xu?ng ph�a d??i
    //            gameObjectIndex = Random.Range(15, 20); // S? d?ng m?t d?i s? kh�c cho h??ng y
    //        }
    //    }

    //    // ??nh ngh?a v? tr� cho game object
    //    float c = Random.Range(-6, 6);
    //    Vector2 position = new Vector2(transform.position.x + c, transform.position.y + 10);

    //    // T?o game object d?a tr�n h??ng
    //    switch (gameObjectIndex)
    //    {
    //        case 0:
    //            Instantiate(gameObj_1, position, Quaternion.identity);
    //            break;
    //        case 1:
    //            Instantiate(gameObj_2, position, Quaternion.identity);
    //            break;
    //        case 2:
    //            Instantiate(gameObj_3, position, Quaternion.identity);
    //            break;
    //        case 3:
    //            Instantiate(gameObj_4, position, Quaternion.identity);
    //            break;
    //        case 4:
    //            Instantiate(gameObj_5, position, Quaternion.identity);
    //            break;
    //        case 5:
    //            Instantiate(gameObj_6, position, Quaternion.identity);
    //            break;
    //        case 6:
    //            Instantiate(gameObj_7, position, Quaternion.identity);
    //            break;
    //        case 7:
    //            Instantiate(gameObj_8, position, Quaternion.identity);
    //            break;
    //        case 8:
    //            Instantiate(gameObj_9, position, Quaternion.identity);
    //            break;
    //        default:
    //            Debug.LogWarning("Gi� tr? gameObjectIndex kh�ng h?p l?.");
    //            break;
    //    }
    //}

}
