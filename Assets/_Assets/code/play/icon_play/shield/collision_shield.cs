using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_shield : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tenlua"))
        {

            Destroy(gameObject);
            Debug.Log("da xoa chua");
            Destroy(collision.gameObject);

        }
    }
}
