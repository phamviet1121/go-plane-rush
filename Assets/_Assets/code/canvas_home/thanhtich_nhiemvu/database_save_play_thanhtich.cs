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
   
    void Start()
    {
       
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
       // Debug.Log($"speedCollide= {speedCollide}");
        //Debug.Log($"armorCollide= {armorCollide}");
    }
}


