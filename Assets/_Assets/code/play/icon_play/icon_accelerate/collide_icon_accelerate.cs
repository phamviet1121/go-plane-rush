using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_icon_accelerate : MonoBehaviour
{
    float Accelerate_lifetime = 10f;
    public AudioSource audioSource;
    void Update()
    {
        Destroy(gameObject, Accelerate_lifetime);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             audioSource.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
