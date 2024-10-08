using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_icon_Destruction : MonoBehaviour
{
    float Destruction_lifetime = 10f;
    public AudioSource audioSource;
    public Summary summary;
    void Update()
    {
        Destroy(gameObject, Destruction_lifetime);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            summary.point_Destruction += 1;
            audioSource.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
