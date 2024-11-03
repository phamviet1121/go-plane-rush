using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class database_save_play_thanhtich : MonoBehaviour
{
    public int starCollide;//sao-
    public int speedCollide;//tocdo-
    public int armorCollide;//giap-
    public int minutes;//thoigian-
    public int rocketsCollide;//tenlua-
    public int destructionCollide;//phahuy
    public Summary Summary;
    public int  savefloat_minutes;

    [ContextMenu("save_sao")]
    public void save_minutes()
    {
        PlayerPrefs.SetInt(nameof(savefloat_minutes), savefloat_minutes);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        save_minutes();
    }

    [ContextMenu("load_sao")]
    public void load_minutes()
    {
        savefloat_minutes = PlayerPrefs.GetInt(nameof(savefloat_minutes), 0);

    }
    void Start()
    {
        load_minutes();
    }

    // Update is called once per frame
    void Update()
    {

        minutes = Summary.point_time / 60;
        starCollide = Summary.point_star;
        speedCollide= Summary.point_accelerate;
        armorCollide= Summary.point_shield;
        rocketsCollide= Summary.point_rockets;
        destructionCollide = Summary.point_Destruction;
        if(Summary.point_time / 60>= savefloat_minutes)
        {
            savefloat_minutes = Summary.point_time / 60;
            save_minutes();
            load_minutes();
        }    
       // Debug.Log($"speedCollide= {speedCollide}");
        //Debug.Log($"armorCollide= {armorCollide}");
    }
}


