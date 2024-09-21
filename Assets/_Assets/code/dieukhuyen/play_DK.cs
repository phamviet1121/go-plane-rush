using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_DK : MonoBehaviour
{
    public GameObject macdinh;
    public GameObject home;
    public GameObject play;


    public GameObject caidat;
    public GameObject dk_play;
    public GameObject tamdung;

    public void onclick_play()
    {
        macdinh.SetActive(false);
        home.SetActive(false);
        play.SetActive(true);
    }
    public void onclick_tamdung()
    {
        dk_play.SetActive(false);
        tamdung.SetActive(true);
    }
    public void onClick_play_tieptuc()
    {

        dk_play.SetActive(true);
        tamdung.SetActive(false);

    }
    public void onClick_play_choilai()
    {

        dk_play.SetActive(true);
        tamdung.SetActive(false);

    }
    public void onClick_home()
    {

        dk_play.SetActive(true);
        tamdung.SetActive(false);
        play.SetActive(false);
        macdinh.SetActive(true);
        home.SetActive(true);
    }
    public void onclick_caidatplay()
    {
        
        caidat.SetActive(true);
        tamdung.SetActive(false);
    }

}
