using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dk_gameover : MonoBehaviour
{
    // public time_play time;
    public GameObject game_over;
    public GameObject dk;
    public home_dk HomeDK;
    public time_play time;
    public GameObject home;
    public GameObject play;
    public GameObject macdinh;
    public GameObject thanhtich;
    public GameObject caidat;
    // public GameObject dk_play;
    public bool gameover;
    public Summary summary;
    public list_sao List_sao;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game_over.activeSelf == true)
        {
            dk.SetActive(false);
        }


    }
    public void choilai_gameover()
    {
        List_sao.save_int_sao += summary.Summary_gameplay;
        List_sao.save_sao();
        List_sao.load_sao();

        dk.SetActive(true);
        game_over.SetActive(false);
        HomeDK.viewplayer(HomeDK.id);
        Time.timeScale = 1f;
        time.starttime = Time.time;
    }
    public void home_gameover()
    {
        List_sao.save_int_sao += summary.Summary_gameplay;
        List_sao.save_sao();
        List_sao.load_sao();

        dk.SetActive(true);
        play.SetActive(false);
        macdinh.SetActive(true);
        home.SetActive(true);
        game_over.SetActive(false);
        HomeDK.viewplayer(HomeDK.id);

        Time.timeScale = 1f;
        time.starttime = Time.time;
    }
    public void caidat_gameover()
    {
        gameover = true;
        caidat.SetActive(true);
        game_over.SetActive(false);



    }
    public void thanhtich_gameover()
    {
        gameover = true;
        thanhtich.SetActive(true);
        game_over.SetActive(false);

    }
}
