using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditorInternal.VersionControl.ListControl;

public class collideStar_player : MonoBehaviour
{
    public list_sao listStar;
    float Star_lifetime=10f;
    public Summary summary_star;
    public AudioSource audioSource;
    void Start()
    {
        
    }

   
    void Update()
    {
        Destroy(gameObject, Star_lifetime);

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            summary_star.point_star += 1;
            listStar.save_int_sao += 1;
            listStar.save_sao();
            listStar.load_sao();
            Destroy(gameObject, 0.3f);


        }
    }

}
