﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THANHTICH_DK : MonoBehaviour
{
    public GameObject home;      // Canvas home
    public GameObject thanhtich; // Canvas thanhtich
    public Dk_gameover dkgameover;
    public GameObject game_over;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Bật Canvas thanhtich và tắt Canvas home
    public void onclickthanhtich()
    {
        thanhtich.SetActive(true);  // Bật Canvas thanhtich
        home.SetActive(false);      // Tắt Canvas home
      

    }

    // Tắt Canvas thanhtich và bật Canvas home
    public void offclickthanhtich()
    {
       
        if (dkgameover.gameover == true)
        {
            game_over.SetActive(true);
            thanhtich.SetActive(false);
            dkgameover.gameover = false;
        }
        else
        {
            thanhtich.SetActive(false); // Tắt Canvas thanhtich
            home.SetActive(true);
        }
    }
}
