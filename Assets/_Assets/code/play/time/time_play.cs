using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_play : MonoBehaviour
{
    public Text Time_txt;
    public float starttime;
    float timeplay;
    public GameObject dk_player;
    public GameObject play;

    private void Start()
    {
        starttime = Time.time;
    }
    private void Update()
    {
       
            timeplay = Time.time - starttime;
            int timeplay_phut = (int)timeplay / 60;
            int timeplay_giay = (int)timeplay % 60;
            Time_txt.text = string.Format($"{timeplay_phut}:{timeplay_giay}");
        


    }
}