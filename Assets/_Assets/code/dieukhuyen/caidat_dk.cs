using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caidat_dk : MonoBehaviour
{
    public GameObject caidat;
    public GameObject home;
    public GameObject play;
    public GameObject tamdung;

    public bool amthanh;
    public GameObject ing_amthanh_true;
    public GameObject ing_amthanh_false;
    public GameObject nutdk;
    public GameObject volangdk;
    public GameObject chamtaydk;
    public GameObject img_nut;
    public GameObject img_volang;
    public GameObject img_cham;
    int dk = 0;

    public GameObject reset;

    public bool rung = true;
    public GameObject ing_rung_true;
    public GameObject ing_rung_false;

    public DATA_CAIDAT datacaidat;


    public Dk_gameover dkgameover;
    public GameObject game_over;
    void Start()
    {

        datacaidat.Loadcaidat();

        amthanh = (datacaidat.Data_caidat_play.amthanh_cd == 0) ? true : false;
        rung = (datacaidat.Data_caidat_play.rung_cd == 0) ? true : false;
        dk = datacaidat.Data_caidat_play.dk_cd;

        onclickamthanhh();
        onclickdkPlayer();
        onclickrung();
        onclickcaidat();
        offclickcaidat();
    }


    void Update()
    {
       if(amthanh)
        {
           volumeFalse();
          
        }
        else
        {
            volumeTrue();
        }
        amthanh = (datacaidat.Data_caidat_play.amthanh_cd == 0) ? true : false;
    }


    public void onclickcaidat()
    {
        home.SetActive(false);
        caidat.SetActive(true);
    }


    public void offclickcaidat()
    {
        if (play.activeSelf == false)
        {
            home.SetActive(true);
            caidat.SetActive(false);
        }
        else
        {
            if (dkgameover.gameover == true)
            {
                game_over.SetActive(true);
                caidat.SetActive(false);
                dkgameover.gameover = false;
            }
            else
            {
                caidat.SetActive(false);
                tamdung.SetActive(true);
            }

        }

    }


    public void onclickamthanhh()
    {
        if (amthanh)
        {
            amthanh = false;
            ing_amthanh_false.SetActive(true);
            ing_amthanh_true.SetActive(false);
          

        }
        else
        {
            amthanh = true;
            ing_amthanh_false.SetActive(false);
            ing_amthanh_true.SetActive(true);
          
        }
        datacaidat.Data_caidat_play.amthanh_cd = (amthanh == true) ? 1 : 0;
        datacaidat.Savecaidat();
      
    }

    // Hàm điều khiển player
    public void onclickdkPlayer()
    {
        dk++;


        if (dk % 3 == 0)
        {

            img_nut.SetActive(true);
            img_volang.SetActive(false);
            img_cham.SetActive(false);

            nutdk.SetActive(true);
            volangdk.SetActive(false);
            chamtaydk.SetActive(false);

        }
        else if (dk % 3 == 1)
        {

            img_nut.SetActive(false);
            img_volang.SetActive(true);
            img_cham.SetActive(false);

            nutdk.SetActive(false);
            volangdk.SetActive(true);
            chamtaydk.SetActive(false);
        }
        else
        {

            img_nut.SetActive(false);
            img_volang.SetActive(false);
            img_cham.SetActive(true);

            nutdk.SetActive(false);
            volangdk.SetActive(false);
            chamtaydk.SetActive(true);
        }
        datacaidat.Data_caidat_play.dk_cd = (dk - 1) % 3;
        datacaidat.Savecaidat();
        datacaidat.Loadcaidat();
    }



    public void onclickReset()
    {
        reset.SetActive(true);
    }


    public void onclickrung()
    {
        if (rung)
        {
            rung = false;
            ing_rung_false.SetActive(true);
            ing_rung_true.SetActive(false);
        }
        else
        {
            rung = true;
            ing_rung_false.SetActive(false);
            ing_rung_true.SetActive(true);
        }
        datacaidat.Data_caidat_play.rung_cd = (rung == true) ? 1 : 0;
        datacaidat.Savecaidat();
        datacaidat.Loadcaidat();
    }

    public void dieukhoan()
    {

    }
    public void volumeTrue()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = true;
        }
    }
    public void volumeFalse()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = false;
        }
    }
}
