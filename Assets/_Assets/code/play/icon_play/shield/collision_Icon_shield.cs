using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_Icon_shield : MonoBehaviour
{
    float Icon_shield_lifetime = 10f;
    public AudioSource audioSource;
    public Summary summary;
    void Update()
    {
        Destroy(gameObject, Icon_shield_lifetime);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            summary.point_shield+= 1;
            audioSource.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
