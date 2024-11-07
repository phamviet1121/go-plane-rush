using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{

    public int point_time;
    public int point_star;
  public int point_rockets;
    public int point_accelerate;
    public int point_shield;
    public int point_Destruction;

    public int Summary_gameplay;
  
    public Text point_time_txt;
    public Text point_star_txt;
    public Text Summary_txt;
    public Text point_quangcao;
    public time_play Time_play;
    public GameObject game_over;
    public Dk_gameover Dk_gameover;
    float Summary_time;
    public int Summary_savelist;
    public bool onestrart=true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        if (game_over.activeSelf&& onestrart) 
        {

            point_time = (int)(Time_play.timeplay);

            point_time_txt.text = string.Format($"{(int)(point_time / 5)}");
            point_star_txt.text = string.Format($"{(int)(point_rockets + point_star)}");

            Summary_gameplay = (int)(point_time / 5) + (int)(point_rockets + point_star);
            Summary_txt.text = string.Format($"{Summary_gameplay}");
            point_quangcao.text = string.Format($" + {Summary_gameplay}");
            onestrart = false;
        }

        if (!game_over.activeSelf && !Dk_gameover.gameover) 
        {
           
            point_star = 0;
            point_rockets = 0;
            point_shield = 0;
            point_accelerate = 0;
            point_Destruction = 0;
            Debug.Log("có reset ko ha  ");
        }

        //Debug.Log($"game_over.activeSel=  {game_over.activeSelf},,Dk_gameover.gameover={Dk_gameover.gameover}");
    }
    public void datlai()
    {
       

            point_star = 0;
            point_rockets = 0;
            point_shield = 0;
            point_accelerate = 0;
            point_Destruction = 0;
        onestrart = true;
           // Debug.Log("có reset ko  (datlai)");


    }
    public void gameoverright()
    {
        Summary_txt.text = string.Format($"{Summary_gameplay}");

    }    
}
