using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_Icon_shield : MonoBehaviour
{
    float Icon_shield_lifetime = 10f;
    public AudioSource audioSource;
    void Update()
    {
        Destroy(gameObject, Icon_shield_lifetime);

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
