using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vacham_tenlua : MonoBehaviour
{
    public GameObject vuno;
    private GameObject newvuno;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tenlua"))
        {
            Vector2 vitrino = new Vector2(transform.position.x, transform.position.y);
            Destroy(gameObject);
            newvuno = Instantiate(vuno, vitrino, Quaternion.identity);
            Destroy(newvuno, 1.8f);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //Vector2 vitrino = new Vector2(transform.position.x, transform.position.y);

            //newvuno = Instantiate(vuno, vitrino, Quaternion.identity);
            //Destroy(newvuno, 1.8f);
        }
    }
}
