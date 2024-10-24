using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class view_player : MonoBehaviour
{
    public Text tocdo_txt;
    public Text tocdoquay_txt;
    public Text giap_txt;
    public Text gia_txt;
    public list_player listplayer;

    public home_dk homedk;

    public list_sao listsao;

    public GameObject play;
    public GameObject buy;
    bool trangthai;
    int giasao;
    public void Start()
    {
        listplayer.load_list_player();
        listsao.load_sao();
        load_dataplayerview();

    }
    public void load_dataplayerview()
    {
        foreach (var data in listplayer.save_listdataplayer)
        {

            if (data.id == homedk.id)
            {
                tocdo_txt.text = data.tocdo.ToString();
                tocdoquay_txt.text = data.tocdoquay.ToString();
                giap_txt.text = data.giap.ToString();
                gia_txt.text = data.gia.ToString();
                trangthai=data.trangthaisohuu;
                giasao = data.gia;
               // Debug.Log($"{data.gia}");
            }
           // Debug.Log("cochayko");
        }

        trangthaiplay();
        //Debug.Log("cochaykoha");
    }
    public void trangthaiplay()
    {
        if(trangthai)
        {
            buy.SetActive(false);
            play.SetActive(true);
        }
        else
        {
            buy.SetActive(true);
            play.SetActive(false);
        }
    }
    public void onclick_buy()
    {
        if(giasao<= listsao.save_int_sao)
        {
            listsao.save_int_sao = listsao.save_int_sao - giasao;
            trangthai = true;
            upload_play();
            listsao.save_sao();
            listsao.load_sao();
            listplayer.save_list_player();
            listplayer.load_list_player();
        }
       
    }
    public void upload_play()
    {
        foreach (var data in listplayer.save_listdataplayer)
        {

            if (data.id == homedk.id)
            {
                data.trangthaisohuu = true;
            }
        }
        trangthaiplay();
    }

    public void RESET_PLANE()
    {
      
        uploadRESET_play();
        listplayer.save_list_player();
        listplayer.load_list_player();
    }
    public void uploadRESET_play()
    {
        foreach (var data in listplayer.save_listdataplayer)
        {
            if (data.id != 0)
            {
               
                data.trangthaisohuu = false;
                trangthai = data.trangthaisohuu;
                trangthaiplay(); 
            }
        }
        
    }
}
