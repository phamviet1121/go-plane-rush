using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class view_player : MonoBehaviour
{
    public TextMeshProUGUI tocdo_txt;
    public TextMeshProUGUI tocdoquay_txt;
    public TextMeshProUGUI giap_txt;
    public TextMeshProUGUI gia_txt;
   // public list_player listplayer;

    public home_dk homedk;

    public list_sao listsao;

    public GameObject play;
    public GameObject buy;
    bool trangthai;
    int giasao;

    ///
    public quest_list_player Quest_list_player;
    public list_player list_player;

    //public get_data_Player get_Quest;
    //public Transform location;
    //public GameObject sample;
    ////
    //private Dictionary<int, get_data_Player> questDictionaryy = new Dictionary<int, get_data_Player>();


    public void Start()
    {
        
        listsao.load_sao();

        list_player.load_onestartplayert();
        if (list_player.onestartplayer!=0)
        {
            list_player.load_list_player();
           

        }
        load_dataplayerview();
        //

        //foreach (var data in Quest_list_player.DataQuestListPlayer)
        //{

        //    create_something_new(data);
        //}
        //sample.SetActive(false);

    }


    //public void create_something_new (data_quet_player data_quet_player)
    //{
    //    var quest = Instantiate(get_Quest, location);
    //    quest.Setdata(data_quet_player);
    //    questDictionaryy[data_quet_player.id] = quest;
    //}

    public void load_dataplayerview()
    {
        foreach (var data in Quest_list_player.DataQuestListPlayer)
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

            list_player.onestartplayer = 1;
            list_player.save_onestartplayer();

            //listplayer.save_list_player();
            //listplayer.load_list_player();
        }
       
    }
    public void upload_play()
    {
        foreach (var data in Quest_list_player.DataQuestListPlayer)
        {

            if (data.id == homedk.id)
            {
                data.trangthaisohuu = true;
            }
        }
        list_player.save_list_player();
        trangthaiplay();
    }

    public void RESET_PLANE()
    {
      
        uploadRESET_play();
        //listplayer.save_list_player();
        //listplayer.load_list_player();
    }
    public void uploadRESET_play()
    {
        foreach (var data in Quest_list_player.DataQuestListPlayer)
        {
            if (data.id != 0)
            {
               
                data.trangthaisohuu = false;
                trangthai = data.trangthaisohuu;
                trangthaiplay(); 
            }
        }
        list_player.onestartplayer = 1;
        list_player.save_onestartplayer();
        list_player.save_list_player();
    }
}
